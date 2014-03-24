using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using pmm91_vector.Interfaces;

namespace pmm91_vector.Implementation
{
    /// <summary>
    /// Коллекция фигур
    /// </summary>
    class FigureCollection : Interfaces.IFigureCollection
    {
        private IList<IFigure> _figures = new List<IFigure>();

        public IList<Interfaces.IFigure> Selection(Point a, Point b)
        {
            return _figures.Where(x => x.Selection(a,b)).ToList();
        }

        public bool Load(System.IO.Stream fileStream)
        {
            throw new NotImplementedException();
        }

        public bool Save(System.IO.Stream fileName)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(Interfaces.IFigure item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, Interfaces.IFigure item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public Interfaces.IFigure this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Add(Interfaces.IFigure item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Interfaces.IFigure item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Interfaces.IFigure[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(Interfaces.IFigure item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Interfaces.IFigure> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
