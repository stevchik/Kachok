using Kachok.Model.Enum;
using System;
using System.Collections.Generic;

namespace Kachok.Model
{
    public class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfDays { get; set; }
        public Status Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public List<PlanTag> PlanTags { get; set; }
        public List<PlanWorkout> PlanWorkouts { get; set; }
        public List<PlanDay> PlanDays { get; set; }
    }
}
