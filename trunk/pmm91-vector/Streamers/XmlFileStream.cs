using System.IO;
using System.Xml.Serialization;

namespace pmm91_vector.Streamers
{
    public class XmlFileStream : BaseStream
    {
        public XmlFileStream(string fileName)
        {
            this._stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        public override Interfaces.IFigureCollection ReadColection()
        {
            XmlSerializer x = new XmlSerializer(typeof(Interfaces.IFigureCollection));
            return (Interfaces.IFigureCollection)x.Deserialize(this._stream);
        }

        public override void WriteColection(Interfaces.IFigureCollection Collection)
        {
            XmlSerializer x = new XmlSerializer(typeof(Interfaces.IFigureCollection));
            x.Serialize(this._stream, Collection);
        }
    }
}
