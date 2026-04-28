---
kind: property
id: P:Autodesk.Revit.DB.XYZ.Item(System.Int32)
zh: 点
source: html/400363d5-88fa-6586-6a2b-ef0a0ed8d0e2.htm
---
# Autodesk.Revit.DB.XYZ.Item Property

**中文**: 点

Indexed access to coordinates.

## Syntax (C#)
```csharp
public double this[
	int idx
] { get; }
```

## Parameters
- **idx** (`System.Int32`) - Use 0 for X, 1 for Y and 2 for Z.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when an attempt is made to access the coordinate
 with an index that is larger than 2.

