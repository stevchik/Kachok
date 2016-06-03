using Kachok.Data;
using Kachok.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;

namespace Kachok.Controllers
{
    [Produces("application/json")]
    [Route("api/Admin")]
    public class AdminController : Controller
    {
        private IAdminRepository _adminRepository;
        private ILogger<AdminController> _logger;

        public AdminController(IAdminRepository adminRepository, ILogger<AdminController> logger)
        {
            this._adminRepository = adminRepository;
            this._logger = logger;
        }

        // GET: api/Admin/Equipment
        [HttpGet("Equipment")]
        public IEnumerable<Equipment> GetEquipment()
        {
            try
            {
                var results = _adminRepository.GetAllEquipment();

                if (results == null)
                {
                    return new List<Equipment>();
                }

                return results;
                //return Json(Mapper.Map<IEnumerable<StopViewModel>>(results.Stops.OrderBy(s => s.Order)));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get equipment list", ex);
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new List<Equipment>();
            }
        }

        // GET: api/Admin/Equipment
        [HttpGet("MuscleGroups")]
        public IEnumerable<MuscleGroup> GetMuscleGroup()
        {
            try
            {
                var results = _adminRepository.GetAllMuscleGroups();

                if (results == null)
                {
                    return new List<MuscleGroup>();
                }

                return results;
                //return Json(Mapper.Map<IEnumerable<StopViewModel>>(results.Stops.OrderBy(s => s.Order)));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get Muscle Group list", ex);
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new List<MuscleGroup>();
            }
        }
    }
}