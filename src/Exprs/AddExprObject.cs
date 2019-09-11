using System.Collections.Generic;

namespace SuperReadable
{
    public class AddExprObject : IExprObject
    {
        private IExprObject left;
        private IExprObject right;
        private bool isAdd;

        public AddExprObject(IExprObject left, IExprObject right, bool isAdd)
        {
            this.left = left;
            this.right = right;
            this.isAdd = isAdd;
        }

        public string Eval()
        {
            return isAdd ? 
                (int.Parse(left.Eval()) + int.Parse(right.Eval())).ToString() : 
                (int.Parse(left.Eval()) - int.Parse(right.Eval())).ToString();
        }
    }
}