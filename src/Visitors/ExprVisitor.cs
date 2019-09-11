namespace SuperReadable
{
    class ExprVisitor : SuperReadableBaseVisitor<IExprObject>
    {
        public override IExprObject VisitNumberExpr(SuperReadableParser.NumberExprContext context)
        {
            return new NumberExprObject(context.GetChild(0).GetText());
        }

        public override IExprObject VisitParameterExpr(SuperReadableParser.ParameterExprContext context)
        {
            return new ParameterExprObject(context.GetChild(0).GetText());
        }

        public override IExprObject VisitAddExpr(SuperReadableParser.AddExprContext context)
        {
            var left = context.GetRuleContext<SuperReadableParser.ExprContext>(0);
            var right = context.GetRuleContext<SuperReadableParser.ExprContext>(1);

            var isAdd = context.GetChild(1).GetText() == "+";

            var leftObject = Visit(left);
            var rightObject = Visit(right);

            return new AddExprObject(leftObject, rightObject, isAdd);
        }

        public override IExprObject VisitMulExpr(SuperReadableParser.MulExprContext context)
        {
            var left = context.GetRuleContext<SuperReadableParser.ExprContext>(0);
            var right = context.GetRuleContext<SuperReadableParser.ExprContext>(1);

            var isMul = context.GetChild(1).GetText() == "*";

            var leftObject = Visit(left);
            var rightObject = Visit(right);

            return new MulExprObject(leftObject, rightObject, isMul);
        }
        
        public override IExprObject VisitBrancketExpr(SuperReadableParser.BrancketExprContext context)
        {
            return Visit(context.GetRuleContext<SuperReadableParser.ExprContext>(0));
        }
    }
}