---
kind: property
id: P:Autodesk.Revit.DB.BoundingBoxXYZ.MinEnabled(System.Int32)
zh: 包围盒
source: html/a4883a49-f6db-1a7f-74b3-ef3fc985879e.htm
---
# Autodesk.Revit.DB.BoundingBoxXYZ.MinEnabled Property

**中文**: 包围盒

Defines whether the minimum bound is active for given dimension.

## Syntax (C#)
```csharp
public bool this[
	int dim
] { get; set; }
```

## Parameters
- **dim** (`System.Int32`)

## Remarks
Use 0 for X, 1 for Y and 2 for Z.
The entire box must be enabled to have enabled individual bounds.

