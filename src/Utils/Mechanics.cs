using System;
using PokemonOOP.src.Entities.Moves;
using PokemonOOP.src.Entities.Pokedex;
using PokemonOOP.src.Enums;

namespace PokemonOOP.src.Utils
{
    public static class Mechanics
    {
        private static double AttackMultiplier()
        {
            Random random = new Random();

            var randomValue = random.NextDouble() + 0.5;
            var attackMultiplier = randomValue < 0.75 ? 0.75 : randomValue;
            return attackMultiplier;
        }

        private static double AdvantageMultiplier(Move move, Pokemon target)
        {
            switch (move.Type)
            {
                case PokemonType.Fire:
                    switch (target.Type)
                    {
                        case PokemonType.Fire:
                            return 0.5;
                        
                        case PokemonType.Water:
                            return 0.5;

                        case PokemonType.Grass:
                            return 2;

                        case PokemonType.Normal:
                            return 1;
                    }
                    
                    break;
                case PokemonType.Water:
                    switch (target.Type)
                    {
                        case PokemonType.Fire:
                            return 2;
                        
                        case PokemonType.Water:
                            return 0.5;

                        case PokemonType.Grass:
                            return 0.5;

                        case PokemonType.Normal:
                            return 1;
                    }
                    
                    break;

                case PokemonType.Grass:
                    switch (target.Type)
                    {
                        case PokemonType.Fire:
                            return 0.5;
                        
                        case PokemonType.Water:
                            return 2;

                        case PokemonType.Grass:
                            return 0.5;

                        case PokemonType.Normal:
                            return 1;
                    }
                    
                    break;

            }
            return 1;
        }

        private static int DamageCalculation(Pokemon p1, Pokemon p2, Move move)
        {
            double temp = (p1.Attack + move.Power) * AttackMultiplier() * AdvantageMultiplier(move,p2) / p2.Defense;
            int damage = (int)Math.Ceiling(temp);
            return damage;
        }

        public static void PokemonAttack(Pokemon p1, Pokemon p2, Move move)
        {

            int damage = Mechanics.DamageCalculation(p1,p2, move);
            if(!p2.Fainted)
            {
                Console.WriteLine(p1.Name + " used " + move.Name + " on " + p2.Name + " causing " + damage + " points of damage.");
            }
            p2.ReceiveDamage(damage);
        }
    }
}