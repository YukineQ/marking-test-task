using marking_test_task.Config;
using marking_test_task.Helpers;
using marking_test_task.Models;
using marking_test_task.DTOs.Responce;
using marking_test_task.Repositories;
using marking_test_task.Services;
using marking_test_task.Services.Commands;
using System.Windows;

namespace marking_test_task.ViewModel
{
    public class CurrentTaskViewModel : BaseViewModel
    {
        private readonly IDialogService _dialogService;
        private readonly IPalleteRepository _palleteRepository;
        private readonly IMissionRepository _missionRepository;
        private readonly IRequestService _requestService;
        private readonly IPublisher<CurrentTask> _publisher;
        private readonly IBoxRepository _boxRepository;

        private CurrentTask? _currentTask;
        private string _gtin;
        private Package _package;

        public CurrentTask CurrentTask
        {
            get { return _currentTask; }
            set
            {
                _currentTask = value;
                OnPropertyChanged(nameof(CurrentTask));
            }
        }

        private RelayCommand _openDialogCommand;

        public RelayCommand OpenDialogCommand
        {
            get
            {
                return _openDialogCommand ?? (_openDialogCommand = new RelayCommand(OpenDialogAsync));
            }
        }

        private async void OpenDialogAsync(object obj)
        {
            try
            {
                if (_dialogService.OpenFileDialog() == false)
                {
                    return;
                }

                var gtinCodes = await FileService.ReadAll(_dialogService.FilePath);
                var codesEqualsTaskGtin = gtinCodes.Where(x => x.Contains(_gtin));

                if (!IsMissionExists())
                {
                    _missionRepository.Add(CreateMission());
                    _missionRepository.Save();
                }

                _publisher.Notify(_currentTask);
            }
            catch (Exception ex)
            {
                _dialogService.ShowMessage(ex.Message);
            }
        }

        private bool IsMissionExists()
        {
            return _missionRepository.GetSingleById(_currentTask.MissionResponce.Id) != null;
        }

        private Mission CreateMission()
        {
            return new Mission 
            { 
                MissionId = _currentTask.MissionResponce.Id,
                Gtin = _currentTask.MissionResponce.Lot.Product.Gtin,
                BoxCapacity = _currentTask.MissionResponce.Lot.Package.BoxFormat,
                PalleteCapacity = _currentTask.MissionResponce.Lot.Package.PalletFormat,
            }
                .SetPalletes(
                    CreatePalletes().ToList()
            );
        }

        private Pallete[] CreatePalletes()
        {
            var nextPalleteId = _palleteRepository.GetSequence().Seq + 1;
            var nextBoxId = _boxRepository.GetSequence().Seq + 1;

            return Multiplicator.UseMultiple(increment =>
                CreatePalleteModel(nextPalleteId + increment)
                    .SetBoxes([.. CreateBoxes(nextBoxId + increment)]),
                _package.PalletFormat
            );
        }

        private Box[] CreateBoxes(int nextId)
        {
            return Multiplicator.UseMultiple(increment =>
                CreateBoxModel(increment + nextId)
                    .AddBottles(CreateBottles().ToList()),
                _package.PalletFormat
            );
        }

        private Bottle[] CreateBottles()
        {
            return Multiplicator.UseMultiple(idx =>
                    CreateBottleModel(),
                _package.BoxFormat
            );
        }

        private Pallete CreatePalleteModel(int nextId)
        {
            return new Pallete()
                .SetCode(
                    _gtin, 
                    _package.PalletFormat, 
                    nextId
                );
        }

        private Box CreateBoxModel(int id)
        {
            return new Box()
                .SetCode(_gtin, _package.BoxFormat, id);
        }

        private Bottle CreateBottleModel()
        {
            return new Bottle().SetCode(_gtin);
        }

        public CurrentTaskViewModel
        (
            IDialogService dialogService, 
            IPalleteRepository palleteRepository,
            IRequestService requestService,
            IMissionRepository missionRepository,
            IPublisher<CurrentTask> publisher,
            IBoxRepository boxRepository
        )
        {
            _dialogService = dialogService;
            _publisher = publisher;
            _palleteRepository = palleteRepository;
            _requestService = requestService;
            _missionRepository = missionRepository;
            _boxRepository = boxRepository;

            var resourse = _requestService.Get<CurrentTask>(Constants.API_URL);

            _currentTask = resourse.Result;
            _gtin = _currentTask.MissionResponce.Lot.Product.Gtin;
            _package = _currentTask.MissionResponce.Lot.Package;
        }
    }
}
