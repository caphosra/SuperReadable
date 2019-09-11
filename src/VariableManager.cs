using System.Collections.Generic;

namespace SuperReadable
{
    static class VariableManager
    {
        private static Dictionary<string, string> vars = new Dictionary<string, string>();
        public static string RESULT { get; set; }

        public static string GetValue(string name)
        {
            return vars[name];
        }

        public static void SetValue(string name, string value)
        {
            vars[name] = value;
        }
    }
}