﻿using Pokemon_FireRed.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Pokemon_FireRed.Entities.Classes
{
    internal class Pokemon
    {
        public string Name { get; set; }
        public string MySpritePath { get; set; }
        public string WildSpritePath { get; set; }
        public bool Gender { get; set; }
        public int Level { get; set; }
        public int Hp { get; set; }
        public int Attck { get; set; }
        public int Def { get; set; }
        public int SpAttck { get; set; }
        public int SpDef { get; set; }
        public int Speed { get; set; }
        public PokemonSpecies PokeSpecies { get; set; }
        public PokemonType Type { get; set; }
        public PokemonType SecondType { get; set; }

        public List<Attack> Attacks { get; set; } = new List<Attack>();
        public Attack CurrentAttck { get; set; }

        public Pokemon(string name, PokemonType type, PokemonType secondType, int level, 
            PokemonSpecies species,string mySprite,string wildSprite,
            int hp, int attck, int def, int spAttck, int spDef, int speed)
        {
            Name = name;
            Type = type;
            SecondType = secondType;

            PokeSpecies = species;
            MySpritePath = mySprite;
            WildSpritePath = wildSprite;

            Hp = hp;
            Attck = attck;
            Def = def;
            SpAttck = spAttck;
            SpDef = spDef;
            Speed = speed;

        }

        public void LearnAttack(string name, PokemonType type, MoveType move, int power, int accuracy, EffectDetails effect) => 
            Attacks.Add (new Attack(name, type, move, power, accuracy, effect));

        public Attack SelectAttack(int index)
        {
            if (index >= 0 && index < Attacks.Count)
                return CurrentAttck = Attacks[index];

            return CurrentAttck;
        }
    }
}
