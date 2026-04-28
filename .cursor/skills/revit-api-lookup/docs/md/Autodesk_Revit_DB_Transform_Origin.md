---
kind: property
id: P:Autodesk.Revit.DB.Transform.Origin
zh: 原点
source: html/9c67a7e5-c869-bfb9-c6fa-e5ac356868f0.htm
---
# Autodesk.Revit.DB.Transform.Origin Property

**中文**: 原点

Defines the origin of the old coordinate system in the new coordinate system.

## Syntax (C#)
```csharp
public XYZ Origin { get; set; }
```

## Remarks
This corresponds to the fourth column vector of the conventional 3x4 matrix
representation. Also, this is the translation component of the transformation.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the transform is internally marked as read-only.

