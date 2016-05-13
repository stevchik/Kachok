using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kachok.Model
{
    public class PlanDay
    {
        public int Id { get; set; }
        public int PlanId { get; set; }
        public int? PlanWorkoutId { get; set; }
        public PlanWorkout PlanWorkout { get; set; }
        public int DayNumber { get; set; }
    }
}
