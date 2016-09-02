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
using Kachok.Data;

namespace Kachok.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Exercises")]
    public class ExerciseController : Controller
    {
        private ILogger<AdminController> _logger;
        private IExerciseRepository _repository;
        private IAdminRepository _adminRepository;
        private KachokContext _context;

        public ExerciseController(KachokContext context, IExerciseRepository repository, IAdminRepository adminRepository, ILogger<AdminController> logger)
        {
            this._repository = repository;
            this._adminRepository = adminRepository;
            this._logger = logger;
            this._context = context;
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
                Equipments = list
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
                Status = Model.Enum.Status.Active,
                Target = Model.Enum.ExerciseTarget.Isolation,
                Equipments = list
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
                    newExercise.CreatedDate = DateTime.Now;
                    newExercise.CreatedBy = User.Identity.Name;
                    newExercise.UpdatedDate = DateTime.Now;
                    newExercise.UpdatedBy = User.Identity.Name;

                    if (vm.Muscle > 0)
                    {
                        newExercise.TargetMuscleGroup = _adminRepository.GetAllMuscleGroups().First(m => m.Id.Equals(vm.Muscle));
                        _context.MuscleGroups.Attach(newExercise.TargetMuscleGroup);
                    }


                    foreach (ExerciseEquipmentViewModel eeVM in vm.Equipments)
                    {
                        var ee = new ExerciseEquipment();

                        ee.Equipment = _adminRepository.GetAllEquipment().First(m => m.Name.Equals(eeVM.EquipmentName));
                        ee.EquipmentId = ee.Equipment.Id;
                        ee.ExerciseId = newExercise.Id;
                        _context.Equipments.Attach(ee.Equipment);
                        newExercise.ExerciseEquipments.Add(ee);
                    }

                    foreach (string tag in vm.Tags)
                    {
                        var eTag = new ExerciseTag();
                        eTag.Tag = _adminRepository.GetAllTags().First(m => m.Name.Equals(tag));
                        eTag.TagId = eTag.Tag.Id;
                    }

                    _repository.Add(newExercise);
                    _repository.SaveAll();
                    Response.StatusCode = (int)HttpStatusCode.Created;

                    return Json(Mapper.Map<ExerciseViewModel>(newExercise));
                }
            }
            catch (Exception ex)
            {
                Exception exx = ex.InnerException;

                if (exx != null && exx is FieldMappingException)
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