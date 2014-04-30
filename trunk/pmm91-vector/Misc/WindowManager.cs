using System;
using System.Collections.Generic;
using System.Windows.Controls;
using pmm91_vector.Implementation.Commands;
using System.Collections;
using System.Windows;
using System.Windows.Media;

namespace pmm91_vector.Misc
{
    /// <summary>
    /// Менеджер окон
    /// </summary>
    public class WindowManager
    {
        private static WindowManager _instance = null;

        private Panel _parent = null;
        private int _activeWindow = -1;
        private List<GraphicWindow> _windows = null;

        /// <summary>
        /// Конструктор закрыт, т.к. используется шаблон "Одиночка"
        /// </summary>
        private WindowManager()
        {
            this._windows = new List<GraphicWindow>();
        }

        /// <summary>
        /// Сущность объекта-одиночки "менеджер окон"
        /// </summary>
        public static WindowManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new WindowManager();
                return _instance;
            }
        }

        /// <summary>
        /// Родительский элемент для окон
        /// </summary>
        public Panel Parent
        {
            get { return this._parent; }
            set
            {
                if (this.ActiveWindow != null)
                {
                    if (this._parent != null)
                        this._parent.Children.Remove(this.ActiveWindow);
                    if (value != null)
                    {
                        value.Children.Add(this.ActiveWindow);
                    }
                }
                this._parent = value;
            }
        }

        /// <summary>
        /// Создание нового окна; оно будет активным
        /// </summary>
        /// <returns>Возвращает созданное окно</returns>
        public GraphicWindow NewWindow()
        {
            var newWindow = new GraphicWindow();
            this._windows.Add(newWindow);
            if (this.Parent != null)
            {
                if (this._activeWindow >= 0)
                    this.Parent.Children.Remove(this._windows[this._activeWindow]);
                this.Parent.Children.Add(newWindow);
                newWindow.Graph.Init(newWindow);
            }
            this._activeWindow = this._windows.IndexOf(newWindow);



            return newWindow;
        }

        /// <summary>
        /// Удаление окна с заданным индексом
        /// </summary>
        /// <param name="windowID">Индес окна</param>
        /// <returns>Возвращает успешность выполнения операции</returns>
        public bool DeleteWindow(int windowID)
        {
            if (windowID >= 0 && this._windows.Count > windowID)
            {
                this._windows[windowID].Graph.Free_mem();
                if (this.ActiveIndex == windowID && this._windows.Count > 1)
                    this.PrevWindow();
                else
                {
                    if (this.Parent != null)
                        this.Parent.Children.Remove(this.ActiveWindow);
                    this._activeWindow--;
                }
                this._windows.RemoveAt(windowID);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Индексатор окон
        /// </summary>
        /// <param name="windowID">Идентификатор окна</param>
        /// <returns>Возвращает окно с заданным индексом</returns>
        public GraphicWindow this[int windowID]
        {
            get
            {
                if (windowID >= 0 && this._windows.Count > windowID)
                    return this._windows[windowID];
                else
                    throw new IndexOutOfRangeException("Некорректный индекс окна");
            }
        }

        /// <summary>
        /// Получение активного окна (null, если нет такового)
        /// </summary>
        public GraphicWindow ActiveWindow
        {
            get
            {
                if (this.ActiveIndex >= 0)
                    return this._windows[this.ActiveIndex];
                else
                    return null;
            }
        }

        /// <summary>
        /// Получение индекса активного окна (-1, если нет такового)
        /// </summary>
        public int ActiveIndex
        {
            get
            {
                return this._activeWindow;
            }
        }

        /// <summary>
        /// Переключение на следующее окно (циклически)
        /// </summary>
        public void NextWindow()
        {
            if (this.ActiveIndex >= 0 && this._windows.Count > 1)
            {
                if (this.Parent != null)
                    this.Parent.Children.Remove(this.ActiveWindow);
                this._activeWindow++;
                if (this.ActiveIndex >= this._windows.Count)
                    this._activeWindow = 0;
                if (this.Parent != null)
                    this.Parent.Children.Add(this.ActiveWindow);
            }
        }

        /// <summary>
        /// Переключение на предыдущее окно (циклически)
        /// </summary>
        public void PrevWindow()
        {
            if (this.ActiveIndex >= 0 && this._windows.Count > 1)
            {
                if (this.Parent != null)
                    this.Parent.Children.Remove(this.ActiveWindow);
                this._activeWindow--;
                if (this.ActiveIndex < 0)
                    this._activeWindow = this._windows.Count - 1;
                if (this.Parent != null)
                    this.Parent.Children.Add(this.ActiveWindow);
            }
        }
    }
}
