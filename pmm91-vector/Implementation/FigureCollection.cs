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
        private IList<Figure> _figures = new List<Figure>();

        public IList<Interfaces.Figure> Selection(Point a, Point b)
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

        public int IndexOf(Interfaces.Figure item)
        {
            return _figures.IndexOf(item);
        }

        public void Insert(int index, Interfaces.Figure item)
        {
            _figures.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _figures.RemoveAt(index);
        }

        public Interfaces.Figure this[int index]
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

        public void Add(Interfaces.Figure item)
        {
            _figures.Add(item);
        }

        public void Clear()
        {
            _figures.Clear();
        }

        public bool Contains(Interfaces.Figure item)
        {
            return _figures.Contains(item);
        }

        public void CopyTo(Interfaces.Figure[] array, int arrayIndex)
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

        public bool Remove(Interfaces.Figure item)
        {
            return _figures.Remove(item);
        }

        public IEnumerator<Interfaces.Figure> GetEnumerator()
        {
            return _figures.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
