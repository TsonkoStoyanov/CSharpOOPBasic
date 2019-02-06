using System;
using System.Collections.Generic;
using P03_WildFarm.Contracts;
using P03_WildFarm.Factories;
using P03_WildFarm.Models.Foods;

namespace P03_WildFarm.Core
{
    public class Engine
    {
        private FoodFactory foodFactory;
        private BirdFactory birdFactory;
        private MammalFactory mammalFactory;
        private FelineFactory felineFactory;
        private List<IAnimal> animals;
        private IAnimal animal;

        public Engine()
        {
            this.birdFactory = new BirdFactory();
            this.foodFactory = new FoodFactory();
            this.mammalFactory = new MammalFactory();
            this.felineFactory = new FelineFactory();
            this.animals = new List<IAnimal>();
        }
        public void Run()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalInfo = input.Split();
         
                string animalType = animalInfo[0];
                string animalName = animalInfo[1];
                double animalWeight = double.Parse(animalInfo[2]);

             

                if (animalType == "Hen" || animalType == "Owl")
                {
                    double wingSize = double.Parse(animalInfo[3]);

                    animal = birdFactory.CreateBird(animalType, animalName, animalWeight, wingSize);
                }
                else if (animalType == "Dog" || animalType == "Mouse")
                {
                    string livingregion = animalInfo[3];
                    animal = mammalFactory.CreateMammal(animalType, animalName, animalWeight, livingregion);

                }
                else if (animalType == "Cat" || animalType == "Tiger")
                {
                    string livingregion = animalInfo[3];
                    string breed = animalInfo[4];

                    animal = felineFactory.CreateFeline(animalType, animalName, animalWeight, livingregion, breed);
                }

                string[] foodInfo = Console.ReadLine().Split();
                string foodType = foodInfo[0];
                int foodQuantity = int.Parse(foodInfo[1]);

                Food food = foodFactory.CreateFood(foodType, foodQuantity);

                animal.ProduceSound();
                animal.Eat(food);
                animals.Add(animal);

            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}