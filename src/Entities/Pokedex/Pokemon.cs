using System;
using System.Collections.Generic;
using PokemonOOP.src.Enums;
using PokemonOOP.src.Entities.Moves;

namespace PokemonOOP.src.Entities.Pokedex
{
    public class Pokemon
    {
        public string Name { get; set; }

        public PokemonType Type {get; set;}

        public int Hp {get; set;}

        public int Speed { get; set; }
        
        public int Attack { get; set; }

        public int Defense { get; set; }

        public bool Fainted { get; set; }
        

        public Dictionary<string,Move> Moves = new Dictionary<string,Move>();

        public Pokemon(string name, PokemonType type, int hp, int speed, int attack, int defense)
        {
            this.Name = name;
            this.Type = type;
            this.Hp = hp;
            this.Speed = speed;
            this.Attack = attack;
            this.Defense = defense;
            this.Fainted = false;
        }

        public void LearnMove(Move move)
        {
            if(move.Type == this.Type || move.Type == PokemonType.Normal)
            {
                Moves.Add(move.Name,move);
                return;
            }

            Console.WriteLine(this.Name + " cannot use " + move.Name);            
        }

        public void UseMove(string moveName, Pokemon target)
        {
            if(Moves.ContainsKey(moveName))
            {
                Moves[moveName].Use(this, target, Moves[moveName]);
                return;
            }

            Console.WriteLine(this.Name + " don't now the move " + moveName);
        }

        public void ReceiveDamage(int damage)
        {
            if(!this.Fainted)
            {
                this.Hp = this.Hp - damage;

                this.Fainted = this.Hp <= 0 ? true : false;
            }

            if(this.Fainted)
            {
                Console.WriteLine(this.Name + " is fainted and can't fight anymore");
            }

                        
        }

    }
}