using System;

namespace TU_Challenge.Heritage
{
    public class ChatQuiBoite : Chat
    {
        public ChatQuiBoite(string name) : base(name)
        {
        }

        public override int Pattes => 3;

        protected override bool CanEatPoisson()
        {
            return false;
        }
    }
}
