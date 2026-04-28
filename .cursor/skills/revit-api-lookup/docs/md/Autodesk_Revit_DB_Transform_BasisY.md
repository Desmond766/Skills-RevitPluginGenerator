---
kind: property
id: P:Autodesk.Revit.DB.Transform.BasisY
zh: 变换
source: html/dfae1c2b-d0fd-0b56-3610-b7055f4169d3.htm
---
# Autodesk.Revit.DB.Transform.BasisY Property

**中文**: 变换

The basis of the Y axis of this transformation.

## Syntax (C#)
```csharp
public XYZ BasisY { get; set; }
```

## Remarks
The Y axis of the old coordinate system in the new coordinate system, 
or the 2nd column of the conventional 3x4 matrix representation.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the transform is internally marked as read-only.

