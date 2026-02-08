using FiveThreeOne.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiveThreeOne.Domain.Entities
{
    public class MainExercise : BaseEntity
    {
        public string Name { get; set; }
        public List<MainExerciseSet> MainExerciseSets { get; set; }
    }
}
