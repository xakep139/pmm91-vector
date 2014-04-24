using System;
using System.IO;

namespace pmm91_vector.Streamers
{
    /// <summary>
    /// Базовый класс для всех потоков чтения/записи коллекции фигур
    /// </summary>
    public abstract class BaseStream : Stream
    {
        protected Stream _stream = null;
        protected string _fileName = "";

        /// <summary>
        /// Освобождает неуправляемые ресурсы, используемые объектом System.IO.Stream,
        /// а при необходимости освобождает также управляемые ресурсы.
        /// </summary>
        /// <param name="disposing">Значение true позволяет освободить управляемые и неуправляемые ресурсы;
        /// значение false позволяет освободить только неуправляемые ресурсы.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (this._stream != null)
                this._stream.Dispose();
        }

        /// <summary>
        /// Чтение коллекции фигур из потока
        /// </summary>
        /// <param name="collectionType">Тип коллекции фигур</param>
        /// <returns>Возвращает коллекцию фигур</returns>
        abstract public Interfaces.IFigureCollection ReadColection(System.Type collectionType);

        /// <summary>
        /// Запись коллекции фигур в поток
        /// </summary>
        /// <param name="Collection">Коллекция фигур для записи</param>
        abstract public void WriteColection(Interfaces.IFigureCollection Collection);

        #region Реализация абстрактных методов класса Stream

        public override bool CanRead
        {
            get
            {
                if (this._stream != null)
                    return this._stream.CanRead;
                else
                    return false;
            }
        }

        public override bool CanSeek
        {
            get
            {
                if (this._stream != null)
                    return this._stream.CanSeek;
                else
                    return false;
            }
        }

        public override bool CanWrite
        {
            get
            {
                if (this._stream != null)
                    return this._stream.CanWrite;
                else
                    return false;
            }
        }

        public override void Flush()
        {
            if (this._stream != null)
                this._stream.Flush();
        }

        public override long Length
        {
            get
            {
                if (this._stream != null)
                    return this._stream.Length;
                else
                    return -1;
            }
        }

        public override long Position
        {
            get
            {
                if (this._stream != null)
                    return this._stream.Position;
                else
                    return -1;
            }
            set
            {
                if (this._stream != null)
                    this._stream.Position = value;
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (this._stream != null)
                return this._stream.Read(buffer, offset, count);
            else
                return -1;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            if (this._stream != null)
                return this._stream.Seek(offset, origin);
            else
                return -1;
        }

        public override void SetLength(long value)
        {
            if (this._stream != null)
                this._stream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            if (this._stream != null)
                this._stream.Write(buffer, offset, count);
        }

        #endregion
    }
}
