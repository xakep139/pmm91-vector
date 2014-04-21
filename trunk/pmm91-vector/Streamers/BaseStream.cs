using System.IO;

namespace pmm91_vector.Streamers
{
    /// <summary>
    /// Базовый класс для всех потоков чтения/записи коллекции фигур
    /// </summary>
    public abstract class BaseStream : Stream
    {
        protected Stream _stream = null;

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

        ~BaseStream()
        {
            if (this._stream != null)
                this._stream.Close();
        }

        public override bool CanRead
        {
            get { return this._stream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return this._stream.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return this._stream.CanWrite; }
        }

        public override void Flush()
        {
            this._stream.Flush();
        }

        public override long Length
        {
            get { return this._stream.Length; }
        }

        public override long Position
        {
            get
            {
                return this._stream.Position;
            }
            set
            {
                this._stream.Position = value;
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return this._stream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return this._stream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            this._stream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            this._stream.Write(buffer, offset, count);
        }

        #endregion
    }
}
