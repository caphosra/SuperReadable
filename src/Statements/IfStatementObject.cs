using System;
using System.Collections.Generic;

namespace SuperReadable
{
    class IfStatementObject : IStatementObject
    {
        public List<IStatementObject> Children { get; set; } =
            new List<IStatementObject>();

        private IExprObject flag;

        public IfStatementObject(IExprObject expr)
        {
            flag = expr;
        }

        public bool Run()
        {
            if(int.Parse(flag.Eval()) > 0)
            {
                foreach(var statement in Children)
                {
                    var run_flag = statement.Run();
                    if(!run_flag)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}