---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeConstraintFixedSegmentDir.#ctor(Autodesk.Revit.DB.UV)
source: html/e4df5069-042d-ba89-3c92-9abf7a5278a6.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeConstraintFixedSegmentDir.#ctor Method

Create a fixed segment direction constraint.

## Syntax (C#)
```csharp
public RebarShapeConstraintFixedSegmentDir(
	UV dir
)
```

## Parameters
- **dir** (`Autodesk.Revit.DB.UV`) - A fixed direction in UV-space.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - dir has zero length.

