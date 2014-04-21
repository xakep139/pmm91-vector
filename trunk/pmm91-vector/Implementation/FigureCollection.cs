using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

using pmm91_vector.Interfaces;

namespace pmm91_vector.Implementation
{
    /// <summary>
    /// Коллекция фигур
    /// </summary>
    [Serializable()]
    public class FigureCollection : IFigureCollection
    {
        private IList<IFigure> _figures = new List<IFigure>();

        public string FileName
        {
            get;
            set;
        }

        public IList<IFigure> Selection(Point a, Point b)
        {
            return _figures.Where(x => x.Selection(a, b)).ToList();
        }

        public bool Load(Streamers.BaseStream stream)
        {
            if (stream.CanRead)
            {
                var newFigureCollection = (FigureCollection)stream.ReadColection(this.GetType());
                this.FileName = newFigureCollection.FileName;
                this._figures = new List<IFigure>(newFigureCollection._figures);
                return true;
            }
            else
                return false;
        }

        public bool Save(Streamers.BaseStream stream)
        {
            if (stream.CanWrite)
            {
                stream.WriteColection(this);
                return true;
            }
            else
                return false;
        }

        public int IndexOf(IFigure item)
        {
            return _figures.IndexOf(item);
        }

        public void Insert(int index, IFigure item)
        {
            _figures.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _figures.RemoveAt(index);
        }

        public IFigure this[int index]
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

        public void Add(IFigure item)
        {
            _figures.Add(item);
        }

        public void Clear()
        {
            _figures.Clear();
        }

        public bool Contains(IFigure item)
        {
            return _figures.Contains(item);
        }

        public void CopyTo(IFigure[] array, int arrayIndex)
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

        public bool Remove(IFigure item)
        {
            return _figures.Remove(item);
        }

        public IEnumerator<IFigure> GetEnumerator()
        {
            return _figures.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }    
    }
}
