using System;
using System.Collections.Generic;

namespace SuperReadable
{
    public interface IStatementObject
    {
        bool Run();
    }

    public delegate bool Runnable();
}