using System;
using System.Collections.Generic;
using System.Text;

namespace FiveThreeOne.Domain.Entities
{
    public class User : BaseEntity
    {
        public float SquatTM { get; set; }
        public float SquatOneRP { get; set; }
        public float BenchTM { get; set; }
        public float BenchOneRP { get; set; }
        public float DeadliftTM { get; set; }
        public float DeadliftOneRP { get; set; }
        public float MilitaryPressTM { get; set; }
        public float MilitaryPressOneRP { get; set; }
    }
}
