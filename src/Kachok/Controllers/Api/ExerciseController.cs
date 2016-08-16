using Kachok.Model;
using Kachok.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using Kachok.Infrastructure.Extensions;
using AutoMapper;
using System;
using Microsoft.Extensions.Logging;
using Kachok.Data.Interfaces;
using Kachok.Infrastructure;

namespace Kachok.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Exercises")]
    public class ExerciseController : Controller
    {
        private ILogger<AdminController> _logger;
        private IExerciseRepository _repository;

        public ExerciseController(IExerciseRepository repository, ILogger<AdminController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }
        // GET: api/Exercises
        [HttpGet()]
        public IEnumerable<ExerciseViewModel> Get()
        {
            List<ExerciseEquipmentViewModel> list = new List<ExerciseEquipmentViewModel>();
            list.Add(new ExerciseEquipmentViewModel() { Id = 1, EquipmentName = "test" });
            list.Add(new ExerciseEquipmentViewModel() { Id = 2, EquipmentName = "test2" });

            List<ExerciseViewModel> list2 = new List<ExerciseViewModel>();

            list2.Add(new ExerciseViewModel()
            {
                Id = 1,
                Status = Model.Enum.Status.Active,
                Target = Model.Enum.ExerciseTarget.Compound,
                ExerciseEquipments = list
            });

            return list2;
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            List<ExerciseEquipmentViewModel> list = new List<ExerciseEquipmentViewModel>();
            list.Add(new ExerciseEquipmentViewModel() { Id = 1, EquipmentName = "test" });
            list.Add(new ExerciseEquipmentViewModel() { Id = 2, EquipmentName = "test2" });
            return Json(new ExerciseViewModel()
            {
                Id = id,
                Status=Model.Enum.Status.Active,
                Target =Model.Enum.ExerciseTarget.Isolation,
                ExerciseEquipments = list
            });
        }

        [HttpPost]
        public JsonResult Post([FromBody]ExerciseViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newExercise = Mapper.Map<Exercise>(vm);
                    Response.StatusCode = (int)HttpStatusCode.Created;

                    return Json(Mapper.Map<ExerciseViewModel>(newExercise));
                }
            }
            catch (Exception ex)
            {
                Exception exx = ex.InnerException;

                if (exx!= null && exx is FieldMappingException)
                {
                    FieldMappingException fme = (FieldMappingException)ex.InnerException;
                    fme.LogException(_logger, $"TargetMuscleGroup({fme.FieldName}) - {fme.Message}");
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json(new { Errors = fme.GetViewModelErrors() });
                }
                else
                {
                    ex.LogException(_logger, "Exception posting exercise");
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json(new { Errors = ex.GetViewModelErrors() });
                }
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Errors = ModelState.GetViewModelErrors() });
        }
    }
}