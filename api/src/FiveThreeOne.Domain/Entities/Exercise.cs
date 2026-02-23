using FiveThreeOne.Domain.Enums;

namespace FiveThreeOne.Domain.Entities
{
    public class Exercise : BaseEntity
    {
        public string Name { get; set; }
        public ExerciseMovementPatternType MovementPatternType { get; set; }
    }
}
