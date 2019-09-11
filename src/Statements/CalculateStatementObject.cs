namespace SuperReadable
{
    class CalculateStatementObject : IStatementObject
    {
        private IExprObject expr;

        public CalculateStatementObject(IExprObject expr)
        {
            this.expr = expr;
        }

        public bool Run()
        {
            VariableManager.RESULT = expr.Eval();
            return true;
        }
    }
}