using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace pmm91_vector.Streamers
{
    public sealed class XmlFileStream : BaseStream
    {
        public XmlFileStream(string fileName)
        {
            this._fileName = fileName;
            this._stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        public override Interfaces.IFigureCollection ReadColection(Type collectionType)
        {
            XmlSerializer x = new XmlSerializer(collectionType);
            using (var reader = XmlReader.Create(this._stream, new XmlReaderSettings { CloseInput = false }))
                return (Interfaces.IFigureCollection)x.Deserialize(reader);
        }

        public override void WriteColection(Interfaces.IFigureCollection Collection)
        {
            XmlSerializer x = new XmlSerializer(Collection.GetType());
            using (var writer = XmlWriter.Create(this._stream, new XmlWriterSettings {  Indent = true,
                                                                                        CloseOutput = false,
                                                                                        NewLineOnAttributes = true }))
                x.Serialize(writer, Collection);
        }
    }
}
