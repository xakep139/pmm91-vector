using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32.SafeHandles;

namespace pmm91_vector.Streamers
{
    public class BinaryFileStream : BaseStream
    {
        public BinaryFileStream(string fileName)
        {
            this._fileName = fileName;
            this._stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        public BinaryFileStream(SafeFileHandle fileHandle)
        {;
            this._stream = new FileStream(fileHandle, FileAccess.ReadWrite);
        }

        public override Interfaces.IFigureCollection ReadColection(Type collectionType)
        {
            BinaryFormatter deserializer = new BinaryFormatter();
            return (Interfaces.IFigureCollection)deserializer.Deserialize(this._stream);
        }

        public override void WriteColection(Interfaces.IFigureCollection Collection)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(this._stream, Collection);
        }
    }
}
