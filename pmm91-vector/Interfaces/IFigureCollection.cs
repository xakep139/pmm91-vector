using System;
using System.Collections;
using System.Collections.Generic;

namespace pmm91_vector.Interfaces
{
    interface IFigureCollection<IFigure> : ICollection, ICollection<IFigure>
    {
    }
}
