using System;

namespace TU_Challenge.Heritage
{
    public abstract class Animal
    {
        protected bool IsHungry = true;

        public abstract int Pattes { get; }

        internal abstract string Crier();

        public virtual void Feed()
        {
            IsHungry = false;
        }

        public virtual void OnAnimalAdded(Animal addedAnimal)
        {
        }
    }
}
