using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kachok.ViewModel
{
    public class ViewModelError
    {
        public string Field { get; set; }
        public List<string> Errors { get; set; }
        public List<string> Exceptions { get; internal set; }
    }
}
