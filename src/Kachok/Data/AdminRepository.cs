using Kachok.Data.Interfaces;
using Kachok.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kachok.Data
{
    public class AdminRepository: IAdminRepository
    {

        private KachokContext _context;
        private ILogger<AdminRepository> _logger;

        public AdminRepository(KachokContext context, ILogger<AdminRepository> logger)
        {
            this._context = context;
            this._logger = logger;
        }

        public IEnumerable<Equipment> GetAllEquipment()
        {
            try
            {
                _logger.LogInformation("Get All Equipment Requested");
                return _context.Equipments.OrderBy(t => t.Name).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get equipment from database", ex);
                return null;
            }
        }

        public IEnumerable<MuscleGroup> GetAllMuscleGroups()
        {
            try
            {
                _logger.LogInformation("Get All Muscle Groups Requested");
                return _context.MuscleGroups.OrderBy(t => t.Name).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get muscle groups from database", ex);
                return null;
            }
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
