using Kachok.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Kachok.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Exercises")]
    public class ExerciseController : Controller
    {
        // GET: api/Exercises
        [HttpGet()]
        public IEnumerable<Exercise> Get()
        {
            return new List<Exercise>();
        }
    }
}