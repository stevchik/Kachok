using System.Collections.Generic;
using Kachok.Model;

namespace Kachok.Data
{
    public interface IAdminRepository
    {
        IEnumerable<Equipment> GetAllEquipment();
        IEnumerable<MuscleGroup> GetAllMuscleGroups();
        bool SaveAll();
    }
}