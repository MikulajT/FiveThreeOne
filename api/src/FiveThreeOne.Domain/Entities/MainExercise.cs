namespace FiveThreeOne.Domain.Entities
{
    public class MainExercise : BaseEntity
    {
        public Exercise Exercise { get; set; }
        public List<MainExerciseSet> MainExerciseSets { get; set; }
    }
}
