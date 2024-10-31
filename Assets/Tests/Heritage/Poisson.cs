using System;

namespace TU_Challenge.Heritage
{
    public class Poisson : Animal
    {
        public bool IsAlive { get; private set; } = true;

        private string _name;

        public Poisson(string name)
        {
            _name = name + " le poisson";
        }

        public string Name => _name;

        public override int Pattes => 0;

        internal override string Crier()
        {
            return string.Empty;
        }

        public void Die()
        {
            IsAlive = false;
        }
    }
}
