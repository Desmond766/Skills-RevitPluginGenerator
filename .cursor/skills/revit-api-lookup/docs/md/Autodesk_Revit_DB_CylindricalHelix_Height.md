---
kind: property
id: P:Autodesk.Revit.DB.CylindricalHelix.Height
zh: 高度
source: html/98caadf4-9780-2cf9-c089-e3501979250b.htm
---
# Autodesk.Revit.DB.CylindricalHelix.Height Property

**中文**: 高度

Height of the cylindrical helix.

## Syntax (C#)
```csharp
public double Height { get; }
```

## Remarks
It is the length of the span of the helix along the axis direction.
 The height is defined only if the helix is bounded. 
 That is, its start and end angles (parameters) are specified.

## Exceptions
- **Autodesk.Revit.Exceptions.InapplicableDataException** - Height is not defined for unbounded helix.

