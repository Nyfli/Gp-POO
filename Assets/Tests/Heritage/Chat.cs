using System;

namespace TU_Challenge.Heritage
{
    public class Chat : Animal
    {
        private int _pattes = 4;
        private string _name;
        private bool _hasEatenPoisson = false;

        public event Action OnDie;

        public Chat(string name)
        {
            this._name = name;
        }

        public override int Pattes => _pattes;

        internal string Name => _name;

        internal override string Crier()
        {
            if (_hasEatenPoisson)
                return "Miaou (Le poisson etait bon)";
            else if (IsHungry)
                return "Miaou (j'ai faim)";
            else
                return "Miaou (c'est bon laisse moi tranquille humain)";
        }

        public void Die()
        {
            OnDie?.Invoke();
        }

        public override void OnAnimalAdded(Animal addedAnimal)
        {
            if (addedAnimal is Poisson poisson && poisson.IsAlive && IsHungry && CanEatPoisson())
            {
                poisson.Die();
                IsHungry = false;
                _hasEatenPoisson = true;
            }
        }

        protected virtual bool CanEatPoisson()
        {
            return true;
        }
    }
}
