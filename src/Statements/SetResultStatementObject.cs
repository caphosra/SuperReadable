namespace SuperReadable
{
    class SetResultStatementObject : IStatementObject
    {
        private string name;

        public SetResultStatementObject(string name)
        {
            this.name = name;
        }

        public bool Run()
        {
            VariableManager.SetValue(name, VariableManager.RESULT);
            return true;
        }
    }
}