using marking_test_task.Helpers;
using marking_test_task.Models;
using marking_test_task.Models.Responce;
using marking_test_task.Repositories;
using marking_test_task.Services;
using marking_test_task.Services.Commands;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows;

namespace marking_test_task.ViewModel
{
    public class PalleteViewModel: BaseViewModel
    {
        private readonly IPalleteRepository _palleteRepository;
        private readonly IPublisher<CurrentTask> _publisher;
        private readonly IAllocationMapService _allocationMapService;

        private CurrentTask _currentTask;

        private ObservableCollection<Pallete> _palletes;

        public ObservableCollection<Pallete> Palletes
        {
            get => _palletes;
            set => SetProperty(ref _palletes, value, nameof(Palletes));
        }

        private RelayCommand _exportToJson;

        public RelayCommand ExportToJson
        {
            get
            {
                return _exportToJson ?? (_exportToJson = new RelayCommand(ExportToJsonAsync));
            }
        }

        private async void ExportToJsonAsync(object _)
        {
            try
            {
               await _allocationMapService.GenerateMap(_currentTask);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public PalleteViewModel
        (
            IPalleteRepository palleteRepository, 
            IPublisher<CurrentTask> publisher, 
            IAllocationMapService allocationMapService
        )
        {
            _publisher = publisher;
            _palleteRepository = palleteRepository;
            _allocationMapService = allocationMapService;

            _publisher.OnChange += GetData;
        }

        private void GetData(object? sender, MessageArgument<CurrentTask> e)
        {
            Palletes = new(_palleteRepository.GetAllByMissionId(e.Message.MissionResponce.Id));
            _currentTask = e.Message;
        }
    }
}
