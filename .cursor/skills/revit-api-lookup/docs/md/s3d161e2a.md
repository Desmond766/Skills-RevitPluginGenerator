---
kind: method
id: M:Autodesk.Revit.DB.Electrical.Wire.AppendVertex(Autodesk.Revit.DB.XYZ)
source: html/fd3b4f99-3178-a3f9-c88d-2fd1a0a34fc5.htm
---
# Autodesk.Revit.DB.Electrical.Wire.AppendVertex Method

Appends one vertex to the end of the wire.

## Syntax (C#)
```csharp
public void AppendVertex(
	XYZ vertexPoint
)
```

## Parameters
- **vertexPoint** (`Autodesk.Revit.DB.XYZ`) - The vertex to be appended.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The vertex point cannot be added to the wire because there is already a vertex at this position on the view plane (within tolerance).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The end point is already connected to an element, so a new endpoint vertex cannot be appended.

