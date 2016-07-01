namespace Kachok.Model
{
    public class PlanTag
    {
        public int Id { get; set; }

        public int PlanId { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
