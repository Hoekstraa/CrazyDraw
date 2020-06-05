using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyDraw.Figures
{
    partial interface IFigure
    {
        internal interface IVisitor
        {
            public void Visit(BasicFigure basicFigure);
            public void Visit(Group group);
        }
    }
}
