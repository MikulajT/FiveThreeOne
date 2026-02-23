namespace FiveThreeOne.Domain.Entities
{
    public class Workout : BaseEntity
    {
        public int Week { get; set; }
        public int HighestTM { get; set; }
        public int WorkoutNumber { get; set; }
        public MainExercise MainExercise { get; set; }
        public List<AssistanceExercise> AssistanceExercises { get; set; }
    }
}
