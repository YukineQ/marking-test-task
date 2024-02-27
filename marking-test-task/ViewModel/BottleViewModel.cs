using marking_test_task.Helpers;
using marking_test_task.Models;
using marking_test_task.Models.Responce;
using marking_test_task.Repositories;
using marking_test_task.Services;
using marking_test_task.Services.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace marking_test_task.ViewModel
{
    public class BottleViewModel : BaseViewModel
    {
        private readonly IBottleRepository _bottleRepository;
        private readonly IPublisher<CurrentTask> _publisher;

        private ObservableCollection<Bottle> _bottles;

        public ObservableCollection<Bottle> Bottles
        {
            get => _bottles;
            set => SetProperty(ref _bottles, value, nameof(Bottles));
        }

        public BottleViewModel
        (
            IBottleRepository bottleRepository,
            IPublisher<CurrentTask> publisher
        )
        {
            _bottleRepository = bottleRepository;
            _publisher = publisher;

            _publisher.OnChange += GetData;
        }

        private void GetData(object? sender, MessageArgument<CurrentTask> e)
        {
            var missionId = e.Message.MissionResponce.Id;
            Bottles = new(_bottleRepository.GetAllByMissionId(missionId));
        }
    }
}
