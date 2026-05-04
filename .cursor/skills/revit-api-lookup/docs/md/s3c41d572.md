---
kind: method
id: M:Autodesk.Revit.DB.Electrical.Wire.IsVertexPointValid(Autodesk.Revit.DB.XYZ)
source: html/fbb3ef78-b28c-9637-b995-b03e461bc9a4.htm
---
# Autodesk.Revit.DB.Electrical.Wire.IsVertexPointValid Method

Checks if the given vertex point can be added to this wire.

## Syntax (C#)
```csharp
public bool IsVertexPointValid(
	XYZ vertexPoint
)
```

## Parameters
- **vertexPoint** (`Autodesk.Revit.DB.XYZ`) - The vertex point.

## Returns
True if the vertex point can be added, false if the point cannot be added because there is already a vertex at this position on the view plane (within tolerance).

## Remarks
Vertices are projected to the view plane for comparison.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

