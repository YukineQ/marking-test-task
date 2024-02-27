using marking_test_task.Helpers;
using marking_test_task.Models;
using marking_test_task.Models.Responce;
using marking_test_task.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marking_test_task.ViewModel
{
    public class BoxViewModel : BaseViewModel
    {
        private readonly IBoxRepository _boxRepository;

        private readonly IPublisher<CurrentTask> _publisher;

        private ObservableCollection<Box> _boxes;

        public ObservableCollection<Box> Boxses
        {
            get => _boxes;
            set => SetProperty(ref _boxes, value, nameof(Boxses));
        }

        public BoxViewModel(IBoxRepository boxRepository, IPublisher<CurrentTask> publisher)
        {
            _boxRepository = boxRepository;
            _publisher = publisher;

            _publisher.OnChange += GetData;
        }
        private void GetData(object? sender, MessageArgument<CurrentTask> e)
        {
            var missionId = e.Message.MissionResponce.Id;
            Boxses = new(_boxRepository.GetAllByMissionId(missionId));
        }
    }
}
