namespace SuperReadable
{
    class StatementVisitor : SuperReadableBaseVisitor<IStatementObject>
    {
        public override IStatementObject VisitFile(SuperReadableParser.FileContext context)
        {
            var file = new FileObject();

            var statements = context.GetRuleContexts<SuperReadableParser.StatementContext>();

            foreach(var statement in statements)
            {
                var statementObj = Visit(statement);
                file.Children.Add(statementObj.Run);
            }

            return file;
        }

        public override IStatementObject VisitCalculateStatement(SuperReadableParser.CalculateStatementContext context)
        {
            var expr = context.GetRuleContext<SuperReadableParser.ExprContext>(0);

            var visitor = new ExprVisitor();
            var exprObj = visitor.Visit(expr);

            return new CalculateStatementObject(exprObj);
        }

        public override IStatementObject VisitPrintStatement(SuperReadableParser.PrintStatementContext context)
        {
            var name = context.GetChild(1).GetText();

            return new PrintStatementObject(name);
        }

        public override IStatementObject VisitSetResultStatement(SuperReadableParser.SetResultStatementContext context)
        {
            var name = context.GetChild(1).GetText();

            return new SetResultStatementObject(name);
        }

        public override IStatementObject VisitIfStatement(SuperReadableParser.IfStatementContext context)
        {
            var flag = context.GetRuleContext<SuperReadableParser.ExprContext>(0);

            var visitor = new ExprVisitor();
            var flagObj = visitor.Visit(flag);

            var ifStatementObj = new IfStatementObject(flagObj);

            var statements = context.GetRuleContexts<SuperReadableParser.StatementContext>();

            foreach(var statement in statements)
            {
                var statementObj = Visit(statement);
                ifStatementObj.Children.Add(statementObj);
            }

            return ifStatementObj;
        }

        public override IStatementObject VisitRepeatStatement(SuperReadableParser.RepeatStatementContext context)
        {
            var repeatStatementObject = new RepeatStatementObject();

            var statements = context.GetRuleContexts<SuperReadableParser.StatementContext>();

            foreach(var statement in statements)
            {
                var statementObj = Visit(statement);
                repeatStatementObject.Children.Add(statementObj);
            }

            return repeatStatementObject;
        }

        public override IStatementObject VisitGoOutStatement(SuperReadableParser.GoOutStatementContext context)
        {
            return new GoOutStatementObject();
        }
    }
}