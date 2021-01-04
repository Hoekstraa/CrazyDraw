namespace CrazyDraw.Figures
{
    partial interface IFigure
    {
        internal class SelectVisitor : IVisitor
        {
            bool select;
            public SelectVisitor(bool select = true)
            {
                this.select = select;
            }

            public void Visit(BasicFigure f)
            {
                if (select)
                    f.selected = true;
                else
                    f.selected = false;
            }

            public void Visit(Group f)
            {
                if (select)
                    f.selected = true;
                else
                    f.selected = false;
            }

            public void Visit(DecoratedFigure f)
            {
                if (select)
                    f.selected = true;
                else
                    f.selected = false;
            }
        }
    }
}
