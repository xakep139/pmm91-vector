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
            return _figures.IndexOf(item);
        }

        public void Insert(int index, Interfaces.IFigure item)
        {
            _figures.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _figures.RemoveAt(index);
        }

        public Interfaces.IFigure this[int index]
        {
            get
            {
                return _figures[index];
            }
            set
            {
                _figures[index] = value;
            }
        }

        public void Add(Interfaces.IFigure item)
        {
            _figures.Add(item);
        }

        public void Clear()
        {
            _figures.Clear();
        }

        public bool Contains(Interfaces.IFigure item)
        {
            return _figures.Contains(item);
        }

        public void CopyTo(Interfaces.IFigure[] array, int arrayIndex)
        {
            _figures.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _figures.Count; }
        }

        public bool IsReadOnly
        {
            get { return _figures.IsReadOnly; }
        }

        public bool Remove(Interfaces.IFigure item)
        {
            return _figures.Remove(item);
        }

        public IEnumerator<Interfaces.IFigure> GetEnumerator()
        {
            return _figures.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
