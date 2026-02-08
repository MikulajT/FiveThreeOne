using System;
using System.Collections.Generic;
using System.Text;

namespace FiveThreeOne.Domain.Entities
{
    public class AssistanceExercise : BaseEntity
    {
        public string Name { get; set; }
        public int MinRepsAmount { get; set; }
        public int MaxRepsAmount { get; set; }
    }
}
