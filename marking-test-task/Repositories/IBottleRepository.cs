using marking_test_task.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marking_test_task.Repositories
{
    public interface IBottleRepository
    {
        Bottle GetSingle(int id);
        void Add(Bottle bottle);
        List<Bottle> GetAllByMissionId(int missionId);
        List<Bottle> GetAll();
    }
}
