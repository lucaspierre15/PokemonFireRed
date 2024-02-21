using Pokemon_FireRed.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon_FireRed.Entities.Classes
{
    internal class Attack
    {
        public string Name { get; set; }
        public PokemonType Type { get; set; }
        public MoveType MType { get; set; }
        public int Power { get; set; }
        public int Accuracy { get; set; }
            
        public Attack(string name, PokemonType type, MoveType mType, int power, int accuracy, EffectDetails effect)
        {
            Name = name;
            Type = type;
            MType = mType;
            Power = power;
            Accuracy = accuracy;
        }


    }
}
