using System;
using System.Collections.Generic;
using System.Linq;

namespace P11_PokemonTrainer
{
    public class Trainer
    {
        private string name;

        private int numberOfBadges;

        private List<Pokemon> pokemons;

        public Trainer(string name)
        {
            this.Name = name;
            this.NumberOfBadges = 0;
            this.pokemons = new List<Pokemon>();

        }

        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }

        }

        public int NumberOfBadges
        {
            get { return numberOfBadges; }
            set { numberOfBadges = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public void Add(Pokemon pokemon)
        {
            this.Pokemons.Add(pokemon);
        }



        internal void DecreaseHealth()
        {
            foreach (var pokemon in pokemons)
            {
                pokemon.Health -= 10;
            }

            pokemons.RemoveAll(x => x.Health <= 0);

        }

        public override string ToString()
        {
            return $"{this.Name} {this.NumberOfBadges} {this.pokemons.Count(x => x.Health > 0)}";
        }
    }
}