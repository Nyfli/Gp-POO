using System;
using System.Collections.Generic;

namespace TU_Challenge.Heritage
{
    public class Animalerie
    {
        private List<Animal> Animals = new List<Animal>();

        public event Action<Animal> OnAddAnimal;

        public void AddAnimal(Animal animal)
        {
            foreach (var existingAnimal in Animals)
            {
                animal.OnAnimalAdded(existingAnimal);
            }

            Animals.Add(animal);
            OnAddAnimal?.Invoke(animal);

            foreach (var existingAnimal in Animals)
            {
                if (existingAnimal != animal)
                {
                    existingAnimal.OnAnimalAdded(animal);
                }
            }
        }

        public bool Contains(Animal animal)
        {
            return Animals.Contains(animal);
        }

        public Animal GetAnimal(int index)
        {
            return Animals[index];
        }

        public void FeedAll()
        {
            foreach (var animal in Animals)
            {
                animal.Feed();
            }
        }
    }
}
