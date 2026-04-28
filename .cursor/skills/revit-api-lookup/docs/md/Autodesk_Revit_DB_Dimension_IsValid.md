---
kind: property
id: P:Autodesk.Revit.DB.Dimension.IsValid
zh: 尺寸标注、标注
source: html/a4382d5b-23af-acd0-1e58-0d964d483482.htm
---
# Autodesk.Revit.DB.Dimension.IsValid Property

**中文**: 尺寸标注、标注

Indicates if this dimension is valid.

## Syntax (C#)
```csharp
public bool IsValid { get; }
```

## Remarks
This property always returns true for model dimensions.
 It can return false for view-specific dimensions that are hidden
 because they are in an invalid state. An example of an invalid
 state is having misaligned references for an aligned dimension.

