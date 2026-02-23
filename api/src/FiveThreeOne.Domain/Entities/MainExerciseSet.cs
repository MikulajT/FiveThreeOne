namespace FiveThreeOne.Domain.Entities
{
    public class MainExerciseSet : BaseEntity
    {
        public int Percentage { get; set; }
        public float Weight { get; set; }
        public int Reps { get; set; }
    }
}
