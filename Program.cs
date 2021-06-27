using System;
using PokemonOOP.src.Entities.Moves;
using PokemonOOP.src.Entities.Pokedex;
using PokemonOOP.src.Enums;
using PokemonOOP.src.Utils;

namespace PokemonOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Pokemon pokemon = new Pokemon("Bulbasaur",PokemonType.Grass,22, 40, 35, 60);

            Pokemon pokemon2 = new Pokemon("Charmander",PokemonType.Fire,10, 60, 47, 32);

            Move move = new Move("Tackle", 40, "A full-body charge attack", PokemonType.Normal);
            move.Use = (p1,p2, move) => {
                Mechanics.PokemonAttack(p1, p2, move);
            };

            Move ember = new Move("Ember", 40, "The foe is attacked with small flames", PokemonType.Fire);
            ember.Use = (p1,p2, ember) => {
                Mechanics.PokemonAttack(p1, p2, move);
            };

            pokemon.LearnMove(move);
            pokemon.UseMove("Tackle",pokemon2);
            pokemon.UseMove("Tackle",pokemon2);
            pokemon.UseMove("Tackle",pokemon2);
            pokemon.UseMove("Tackle",pokemon2);
            pokemon.UseMove("Tackle",pokemon2);
            pokemon.UseMove("Tackle",pokemon2);
            pokemon.UseMove("Tackle",pokemon2);
        }
    }
}
