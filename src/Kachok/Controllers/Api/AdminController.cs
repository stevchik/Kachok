using Kachok.Data.Interfaces;
using Kachok.Model;
using Kachok.Model.Enum;
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

        //[HttpGet("Status")]
        //public IEnumerable<string> GetStatus()
        //{
        //    try
        //    {
        //        return Enum.GetNames(typeof(Status));
                
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Failed to get Status list", ex);
        //        Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //        return new List<string>();
        //    }
        //}

        [HttpGet("Options/{type:regex(Status|ExerciseUom|Experience|ExerciseTarget)}")]
        public IEnumerable<string> GetOptions(string type)
        {
            try
            {
                type = $"Kachok.Model.Enum.{type}";
                return Enum.GetNames(Type.GetType(type));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get Options for {type}", ex);
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new List<string>();
            }
        }
    }
}