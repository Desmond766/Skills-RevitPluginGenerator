---
kind: property
id: P:Autodesk.Revit.DB.Transform.BasisZ
zh: 变换
source: html/f0a5bbf5-41f2-ec36-80c4-207e9bae36d9.htm
---
# Autodesk.Revit.DB.Transform.BasisZ Property

**中文**: 变换

The basis of the Z axis of this transformation.

## Syntax (C#)
```csharp
public XYZ BasisZ { get; set; }
```

## Remarks
The Z axis of the old coordinate system in the new coordinate system, 
or the 3rd column of the conventional 3x4 matrix representation.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the transform is internally marked as read-only.

