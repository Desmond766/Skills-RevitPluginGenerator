---
kind: property
id: P:Autodesk.Revit.DB.BoundingBoxXYZ.BoundEnabled(System.Int32,System.Int32)
zh: 包围盒
source: html/b6b443e6-b188-795d-7bd9-730e61f820c2.htm
---
# Autodesk.Revit.DB.BoundingBoxXYZ.BoundEnabled Property

**中文**: 包围盒

Indexed access for loops.

## Syntax (C#)
```csharp
public bool this[
	int bound,
	int dim
] { get; set; }
```

## Parameters
- **bound** (`System.Int32`)
- **dim** (`System.Int32`)

## Remarks
For bound, use 0 for Min and 1 for Max. For dimension, use 0 for X, 1 for
Y and 2 for Z.
The entire box must be enabled to have enabled individual bounds.

