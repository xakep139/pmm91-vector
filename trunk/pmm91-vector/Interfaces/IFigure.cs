using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace pmm91_vector.Interfaces
{
    /// <summary>
    /// Интерфейс объекта "фигура"
    /// </summary>
    public interface IFigure : IGeometryFigure, IGraphicFigure, IXmlSerializable
    {
    }
}
