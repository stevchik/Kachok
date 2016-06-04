namespace Kachok.Model
{
    public class ExerciseImage
    {
        public int Id { get; set; }
        public int ExerciseId { get; set;}
       
        public string ImageUrl{get;set;}
      
        public string Caption { get; set; }
        public int Sequence { get; set; }

    }
}
