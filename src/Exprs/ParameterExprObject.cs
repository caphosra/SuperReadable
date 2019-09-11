using System.Collections.Generic;

namespace SuperReadable
{
    public class ParameterExprObject : IExprObject
    {
        private string name;

        public ParameterExprObject(string name)
        {
            this.name = name;
        }

        public string Eval()
        {
            return VariableManager.GetValue(name);
        }
    }
}