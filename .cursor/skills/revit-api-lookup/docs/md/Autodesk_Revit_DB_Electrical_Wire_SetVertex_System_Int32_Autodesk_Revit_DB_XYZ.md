---
kind: method
id: M:Autodesk.Revit.DB.Electrical.Wire.SetVertex(System.Int32,Autodesk.Revit.DB.XYZ)
source: html/2caf41e6-d632-f90e-7641-931f8c288c26.htm
---
# Autodesk.Revit.DB.Electrical.Wire.SetVertex Method

Sets the position of a given vertex.
 If the vertex is start or end point, and the wire connects to electrical device, the wire end offset will be set according to the given vertex.
 If the vertex is start or end point, and the wire connects to other wire, user can't set the vertex and exception will be thrown.
 If the vertex is start or end point, and the wire connects to nothing, the vertex will be set as the given vertex.

## Syntax (C#)
```csharp
public void SetVertex(
	int index,
	XYZ vertexPoint
)
```

## Parameters
- **index** (`System.Int32`) - The index of the existing vertex. Should be between 0 and NumberOfVertices .
- **vertexPoint** (`Autodesk.Revit.DB.XYZ`) - The new position for the vertex.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The index should be between 0 and the number of vertices of the wire.
 -or-
 The vertex point cannot be added to the wire because there is already a vertex at this position on the view plane (within tolerance).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Can't set the vertex when the vertex is start or end point and the wire connects to other wire.

