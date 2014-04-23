using System.IO;
using System.Xml.Serialization;

namespace pmm91_vector.Streamers
{
    public class XmlFileStream : BaseStream
    {
        string fname;
        public XmlFileStream(string fileName)
        {
            fname = fileName;
//            this._stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }
        public override bool CanWrite
        {
            get
            {
                return true;
            }
        }
        public override Interfaces.IFigureCollection ReadColection(System.Type collectionType)
        {
            XmlSerializer x = new XmlSerializer(collectionType);
            return (Interfaces.IFigureCollection)x.Deserialize(this._stream);
        }

        public override void WriteColection(Interfaces.IFigureCollection Collection)
        {
            using (var writer = System.Xml.XmlWriter.Create(fname, new System.Xml.XmlWriterSettings { Indent = true, NewLineOnAttributes = true }))
            {
                XmlSerializer x = new XmlSerializer(typeof(pmm91_vector.Implementation.FigureCollection));
                x.Serialize(writer, Collection as pmm91_vector.Implementation.FigureCollection);
            }
        }
    }
}
