using Pokemon_FireRed.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon_FireRed.Entities.Classes
{
    internal class EffectDetails
    {
        public AttackEffect EffectType { get; set; }

        public EffectDetails (AttackEffect effectType)
        {
            EffectType = effectType;
        }
    }
}
