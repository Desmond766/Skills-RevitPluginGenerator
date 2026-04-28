---
kind: property
id: P:Autodesk.Revit.DB.Face.IsCyclic(System.Int32)
source: html/eca99f03-50e0-12bd-8e86-722759a5b612.htm
---
# Autodesk.Revit.DB.Face.IsCyclic Property

Indicates whether the underlying surface is periodic in the specified parametric direction.

## Syntax (C#)
```csharp
public bool this[
	int paramIdx
] { get; }
```

## Parameters
- **paramIdx** (`System.Int32`) - Use 0 for U coordinates and 1 for V coordinates.

## Returns
True if the underlying surface is cyclic in the specified coordinate space; otherwise, false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when an incorrect coordinate dimension is supplied.

