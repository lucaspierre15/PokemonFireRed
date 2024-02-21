using Pokemon_FireRed.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon_FireRed.Entities.Classes
{
    internal class Battle
    {
        public Pokemon CurrentPokemon { get; set; }
        public Pokemon EnemyPokemon { get; set; }
        public BattleState State { get; set; }

        private Random random;

        public Battle(Pokemon currentPokemon, Pokemon enemy)
        {
            CurrentPokemon = currentPokemon;
            EnemyPokemon = enemy;
            State = BattleState.PLAYERTURN;
        }

        public bool TakeDamageEnemy(Attack attack)
        {
            //random = new Random();
            //double modifiers = random.NextDouble() * (1 - 0.85) + 0.85;
            //double a = (2 * CurrentPokemon.Level + 10) / 250;
            //double d = a * attack.Power * (CurrentPokemon.Attck / EnemyPokemon.Def) + 2;
            //damage = d * modifiers;

            double damage;

            random = new Random();
            double modifiers = random.NextDouble() * (1 - 0.85) + 0.85;
            double a = (2 * CurrentPokemon.Level + 10) / 250.0; // Certifique-se de usar a constante como double
            double d = a * attack.Power * (CurrentPokemon.Attck / (double)EnemyPokemon.Def) + 2; // Divida por double para obter resultado fracionário
             damage = Math.Round(d * modifiers); // Use Math.Round para arredondar corretamente

            // Certifique-se de que o dano não seja negativo
            damage = Math.Max(0, damage);

            EnemyPokemon.Hp -= (int)damage;

            if(EnemyPokemon.Hp <= 0)
            {
                EnemyPokemon.Hp = 0;
                return true;
            }

            return false;
        }

        public bool TakeDamagePlayer(Attack attack)
        {
            //random = new Random();
            //double modifiers = random.NextDouble() * (1 - 0.85) + 0.85;
            //double a = (2 * EnemyPokemon.Level + 10) / 250;
            //double d = a * attack.Power * (EnemyPokemon.Attck / CurrentPokemon.Def) + 2;
            //damage = d * modifiers;

            double damage;

            random = new Random();
            double modifiers = random.NextDouble() * (1 - 0.85) + 0.85;
            double a = (2 * EnemyPokemon.Level + 10) / 250.0; // Certifique-se de usar a constante como double
            double d = a * attack.Power * (EnemyPokemon.Attck / (double)CurrentPokemon.Def) + 2; // Divida por double para obter resultado fracionário
            damage = Math.Round(d * modifiers); // Use Math.Round para arredondar corretamente

            // Certifique-se de que o dano não seja negativo
            damage = Math.Max(0, damage);

            CurrentPokemon.Hp -= (int)damage;

            if (CurrentPokemon.Hp <= 0)
            {
                CurrentPokemon.Hp = 0;
                return true;
            }

            return false;
        }

        public Attack GetRandomAttack()
        {
             random = new Random();
            int r = random.Next(0, EnemyPokemon.Attacks.Count);
            return EnemyPokemon.Attacks[r];
        }
    }
}
