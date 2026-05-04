---
kind: method
id: M:Autodesk.Revit.DB.Electrical.Wire.GetVertex(System.Int32)
source: html/e9fbd76e-e1b8-4d11-2368-27998769bc19.htm
---
# Autodesk.Revit.DB.Electrical.Wire.GetVertex Method

Gets the position of an existing vertex.

## Syntax (C#)
```csharp
public XYZ GetVertex(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - The index of the existing vertex. Should be between 0 and NumberOfVertices .

## Returns
The position of the vertex.
 It is the offset point for the start and end vertex, not the connector point.
 If the wire connects to one device, it may have offset; otherwise, the start and end vertex is same as the connector point.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The index should be between 0 and the number of vertices of the wire.
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.

