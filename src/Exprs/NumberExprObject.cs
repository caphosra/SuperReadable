using System.Collections.Generic;

namespace SuperReadable
{
    public class NumberExprObject : IExprObject
    {
        private string number;

        public NumberExprObject(string number)
        {
            this.number = number;
        }

        public string Eval()
        {
            return number;
        }
    }
}