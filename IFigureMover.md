# Интерфейс #

```
public interface IFigureMover
{
    // MoveType - перечислимый тип: перемещение/вращение/масштаб
    bool Move(enum MoveType, Arraylist params);
    // Marker - класс, отвечающий за маркеры фигуры 
    bool MoveMarker(Marker mark, Point newPoint);
}
```