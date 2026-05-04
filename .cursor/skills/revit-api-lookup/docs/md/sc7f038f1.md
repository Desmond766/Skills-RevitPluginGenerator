---
kind: property
id: P:Autodesk.Revit.DB.Face.Period(System.Int32)
source: html/4846f165-5347-a95d-649f-bb907019d28c.htm
---
# Autodesk.Revit.DB.Face.Period Property

The period of the underlying surface in the specified parametric direction.

## Syntax (C#)
```csharp
public double this[
	int paramIdx
] { get; }
```

## Parameters
- **paramIdx** (`System.Int32`) - Use 0 for U coordinates and 1 for V coordinates.

## Returns
The real number equal to the period of the underlying surface.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when an incorrect coordinate dimension is supplied.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when this face is not cyclic in the specified direction.

