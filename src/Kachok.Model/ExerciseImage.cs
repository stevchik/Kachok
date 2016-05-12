using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kachok.Model
{
    public class ExerciseImage
    {
        public int Id { get; set; }
        public int ExerciseId { get; set;}
        public Exercise Exercise { get; set; }

        public string ImageUrl{get;set;}
      
        public string Caption { get; set; }
        public int Sequence { get; set; }

    }
}
