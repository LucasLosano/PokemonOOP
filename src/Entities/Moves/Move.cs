using PokemonOOP.src.Enums;
using PokemonOOP.src.Entities.Pokedex;
using System;

namespace PokemonOOP.src.Entities.Moves
{
    public class Move
    {
        public Move(string name, int power, string description, PokemonType type)
        {
            Name = name;
            Power = power;
            Description = description;
            Type = type;
        }

        public string Name { get; set; }

        public int Power { get; set; }
        
        public string Description { get; set; }

        public PokemonType Type {get; set;}

        public Action<Pokemon, Pokemon, Move> Use;
    }
}