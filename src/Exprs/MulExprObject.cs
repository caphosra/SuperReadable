using System.Collections.Generic;

namespace SuperReadable
{
    public class MulExprObject : IExprObject
    {
        private IExprObject left;
        private IExprObject right;
        private bool isMul;

        public MulExprObject(IExprObject left, IExprObject right, bool isMul)
        {
            this.left = left;
            this.right = right;
            this.isMul = isMul;
        }

        public string Eval()
        {
            return isMul ? 
                (int.Parse(left.Eval()) * int.Parse(right.Eval())).ToString() : 
                (int.Parse(left.Eval()) / int.Parse(right.Eval())).ToString();
        }
    }
}