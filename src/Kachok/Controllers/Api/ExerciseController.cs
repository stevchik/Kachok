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
        public IEnumerable<Exercise> Get()
        {
            return new List<Exercise>();
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
                ex.LogException(_logger, "Exception posting exercise");
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Errors = ex.GetViewModelErrors() });
            }


            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Errors = ModelState.GetViewModelErrors() });


        }
    }
}