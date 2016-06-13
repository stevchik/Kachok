using System.Collections.Generic;
using Kachok.Model;

namespace Kachok.Data.Interfaces
{
    public interface IAdminRepository
    {
        IEnumerable<Equipment> GetAllEquipment();
        IEnumerable<MuscleGroup> GetAllMuscleGroups();
        bool SaveAll();
        IEnumerable<Tag> GetAllTags();
    }
}