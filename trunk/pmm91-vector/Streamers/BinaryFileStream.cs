using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace pmm91_vector.Streamers
{
    public sealed class BinaryFileStream : BaseStream
    {
        private BinaryFormatter formatter = new BinaryFormatter();

        public BinaryFileStream(string fileName)
        {
            this._fileName = fileName;
            this._stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        public override Interfaces.IFigureCollection ReadColection(Type collectionType)
        {
            return (Interfaces.IFigureCollection)formatter.Deserialize(this._stream);
        }

        public override void WriteColection(Interfaces.IFigureCollection Collection)
        {
            formatter.Serialize(this._stream, Collection);
        }
    }
}
