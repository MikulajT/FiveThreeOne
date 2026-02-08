using FiveThreeOne.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiveThreeOne.Domain.Entities
{
    public class Template : BaseEntity
    {
        public string Name { get; set; }
        public TemplateType Type { get; set; }

        List<Workout> Workouts { get; set; }
    }
}
