using System;
using System.Collections.Generic;

namespace SuperReadable
{
    class RepeatStatementObject : IStatementObject
    {
        public List<IStatementObject> Children { get; set; } =
            new List<IStatementObject>();

        public RepeatStatementObject()
        {
            
        }

        public bool Run()
        {
            for(int i = 0; ; i++)
            {
                i %= Children.Count;

                var run_flag = Children[i].Run();

                if(!run_flag)
                {
                    break;
                }
            }
            return true;
        }
    }
}