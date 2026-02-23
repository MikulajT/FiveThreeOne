namespace FiveThreeOne.Domain.Entities
{
    public class AssistanceExercise : BaseEntity
    {
        public Exercise Exercise { get; set; }
        public int MinRepsAmount { get; set; }
        public int MaxRepsAmount { get; set; }
    }
}
