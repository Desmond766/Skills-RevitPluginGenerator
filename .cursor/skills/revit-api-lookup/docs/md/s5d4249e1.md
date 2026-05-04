---
kind: property
id: P:Autodesk.Revit.DB.Dimension.IsLocked
zh: 尺寸标注、标注
source: html/496d64c6-3642-577d-7631-96956baed820.htm
---
# Autodesk.Revit.DB.Dimension.IsLocked Property

**中文**: 尺寸标注、标注

Indicates if this dimension is locked.

## Syntax (C#)
```csharp
public bool IsLocked { get; set; }
```

## Remarks
This property always returns false if the dimension
is a radial or spot dimension. 
This property cannot be set if the dimension has been labeled,
or if the dimension shape is arc-length, radial, diameter or spot,
or if the dimension is linear with more than one segment.

