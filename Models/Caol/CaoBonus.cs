using System;
using System.Collections.Generic;

namespace AgenceTest.Models.Caol
{
    public partial class CaoBonus
    {
        public int BonCategoria { get; set; }
        public int BonInicio { get; set; }
        public int BonFim { get; set; }
        public float? BonValorSem { get; set; }
        public float? BonValorFimsem { get; set; }
    }
}
