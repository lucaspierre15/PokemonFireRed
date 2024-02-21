using Pokemon_FireRed.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon_FireRed.Entities.Classes
{
    internal class EffectDetails
    {
        public AttackEffect EffectType { get; set; }
        public int Accuracy { get; set; } 

        public EffectDetails (AttackEffect effectType, int accuracy)
        {
            EffectType = effectType;
            Accuracy = accuracy;
        }

    }
}
