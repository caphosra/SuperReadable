using System.Collections.Generic;

namespace SuperReadable
{
    public class FileObject : IStatementObject
    {
        public List<Runnable> Children { get; set; } = new List<Runnable>();

        public bool Run()
        {
            foreach(var child in Children)
            {
                child();
            }
            return true;
        }
    }
}