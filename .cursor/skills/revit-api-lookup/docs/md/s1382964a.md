---
kind: method
id: M:Autodesk.Revit.DB.SlabShapeEditor.DrawPoint(Autodesk.Revit.DB.XYZ)
source: html/6f996675-9eed-7e0b-5462-c38bc97e74c6.htm
---
# Autodesk.Revit.DB.SlabShapeEditor.DrawPoint Method

Adds a point to the corresponding slab, roof or floor.

## Syntax (C#)
```csharp
public SlabShapeVertex DrawPoint(
	XYZ location
)
```

## Parameters
- **location** (`Autodesk.Revit.DB.XYZ`) - The location of the point.

## Returns
The newly created vertex.

## Remarks
If the input location is not on the top face of the slab, this function will return Nothing nullptr a null reference ( Nothing in Visual Basic) .
Drawing a point on boundary crease may increase the number of creases.
This method will regenerate the document even in manual regeneration mode.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the location is Nothing nullptr a null reference ( Nothing in Visual Basic) .

