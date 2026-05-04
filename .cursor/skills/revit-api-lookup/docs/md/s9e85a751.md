---
kind: property
id: P:Autodesk.Revit.DB.Transform.BasisX
zh: 变换
source: html/ac4f8d40-cd21-a6ed-0366-61cb86edb757.htm
---
# Autodesk.Revit.DB.Transform.BasisX Property

**中文**: 变换

The basis of the X axis of this transformation.

## Syntax (C#)
```csharp
public XYZ BasisX { get; set; }
```

## Remarks
The X axis of the old coordinate system in the new coordinate system, 
or the 1st column of the conventional 3x4 matrix representation.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the transform is internally marked as read-only.

