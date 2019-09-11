using System;

namespace SuperReadable
{
    class PrintStatementObject : IStatementObject
    {
        private string name;

        public PrintStatementObject(string name)
        {
            this.name = name;
        }

        public bool Run()
        {
            Console.WriteLine(VariableManager.GetValue(name));
            return true;
        }
    }
}