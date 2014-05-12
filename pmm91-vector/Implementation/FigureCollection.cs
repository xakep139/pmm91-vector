using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

using pmm91_vector.Interfaces;

namespace pmm91_vector.Implementation
{
    /// <summary>
    /// Коллекция фигур
    /// </summary>
    [Serializable]
    public class FigureCollection : IFigureCollection
    {
        [NonSerialized]
        private IList<Figures.BaseFigure> _activeFigures = new List<Figures.BaseFigure>();

        private IList<Figures.BaseFigure> _figures = new List<Figures.BaseFigure>();

        public FigureCollection() { }

        public FigureCollection(FigureCollection copy)
        {
            if (copy != null)
            {
                this.FileName = copy.FileName;
                this._activeFigures = new List<Figures.BaseFigure>(copy._activeFigures);
                this._figures = new List<Figures.BaseFigure>(copy._figures);
            }
        }

        public string FileName
        {
            get;
            set;
        }

        /// <summary>
        /// Список активных фигур
        /// </summary>
        public IList<Figures.BaseFigure> ActiveFigures
        {
            get
            {
                return this._activeFigures;
            }
            set
            {
                foreach (var fig in value)
                    if (!this._figures.Contains(fig))
                        throw new Exception("Заданная фигура не содержится в коллекции");
                this._activeFigures = value;
            }
        }

        public IList<Figures.BaseFigure> Selection(Point a, Point b)
        {
            return _figures.Where(x => x.Selection(a, b)).ToList();
        }

        public void Transform(Interfaces.IFigureTransform transformer)
        {
            foreach (var figure in _activeFigures)
            {
                figure.Transform(transformer);
            }
        }

        public bool Load(Streamers.BaseStream stream)
        {
            if (stream.CanRead)
            {
                var newFigureCollection = (FigureCollection)stream.ReadColection(this.GetType());
                this.FileName = newFigureCollection.FileName;
                this._figures = new List<Figures.BaseFigure>(newFigureCollection._figures);
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

        public int IndexOf(Figures.BaseFigure item)
        {
            return _figures.IndexOf(item);
        }

        public void Insert(int index, Figures.BaseFigure item)
        {
            _figures.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _figures.RemoveAt(index);
        }

        public Figures.BaseFigure this[int index]
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

        public void Add(Figures.BaseFigure item)
        {
            _figures.Add(item);
        }

        public void Clear()
        {
            _figures.Clear();
        }

        public bool Contains(Figures.BaseFigure item)
        {
            return _figures.Contains(item);
        }

        public void CopyTo(Figures.BaseFigure[] array, int arrayIndex)
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

        public bool Remove(Figures.BaseFigure item)
        {
            return _figures.Remove(item);
        }

        public IEnumerator<Figures.BaseFigure> GetEnumerator()
        {
            return this._figures.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._figures.GetEnumerator();
        }
    }
}
