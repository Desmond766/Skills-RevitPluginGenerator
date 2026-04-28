---
kind: property
id: P:Autodesk.Revit.DB.Transform.Basis(System.Int32)
zh: 变换
source: html/00944fa6-49d9-4564-9f55-c0f71fa14706.htm
---
# Autodesk.Revit.DB.Transform.Basis Property

**中文**: 变换

Defines the basis of the old coordinate system in the new coordinate system.

## Syntax (C#)
```csharp
public XYZ this[
	int idx
] { get; set; }
```

## Parameters
- **idx** (`System.Int32`) - The index of the basis vector: 0, 1 or 2.

## Remarks
This corresponds to the first three column vectors of the conventional 3x4 matrix
representation.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the given index is larger than 2 in the getter and setter.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the transform is internally marked as read-only.

