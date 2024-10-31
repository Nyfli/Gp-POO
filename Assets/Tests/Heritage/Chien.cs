using System;

namespace TU_Challenge.Heritage
{
    public class Chien : Animal
    {
        private string _name;

        public Chien(string name)
        {
            _name = name;
        }

        public override int Pattes => 4;

        internal string Name => _name;

        internal override string Crier()
        {
            if (IsHungry)
                return "Ouaf (j'ai faim)";
            else
                return "Ouaf (viens on joue ?)";
        }
    }
}
