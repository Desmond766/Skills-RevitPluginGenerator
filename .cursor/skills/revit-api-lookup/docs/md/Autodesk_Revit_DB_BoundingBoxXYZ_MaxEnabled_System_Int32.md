---
kind: property
id: P:Autodesk.Revit.DB.BoundingBoxXYZ.MaxEnabled(System.Int32)
zh: 包围盒
source: html/07f07ae6-88ed-cd88-c7c0-8542865ca96c.htm
---
# Autodesk.Revit.DB.BoundingBoxXYZ.MaxEnabled Property

**中文**: 包围盒

Defines whether the maximum bound is active for given dimension.

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

