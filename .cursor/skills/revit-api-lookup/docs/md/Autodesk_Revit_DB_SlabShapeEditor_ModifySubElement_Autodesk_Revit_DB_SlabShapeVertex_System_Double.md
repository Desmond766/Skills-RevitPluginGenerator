---
kind: method
id: M:Autodesk.Revit.DB.SlabShapeEditor.ModifySubElement(Autodesk.Revit.DB.SlabShapeVertex,System.Double)
source: html/844e2ab1-6c14-4b32-e6f0-ea23baa0ab5d.htm
---
# Autodesk.Revit.DB.SlabShapeEditor.ModifySubElement Method

Manipulates the vertex on the corresponding slab, roof or floor.

## Syntax (C#)
```csharp
public void ModifySubElement(
	SlabShapeVertex vertex,
	double offset
)
```

## Parameters
- **vertex** (`Autodesk.Revit.DB.SlabShapeVertex`) - The vertex.
- **offset** (`System.Double`) - The new value of the vertex offset.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the vertex is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the vertex is invalid.

