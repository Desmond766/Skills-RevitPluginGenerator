---
kind: property
id: P:Autodesk.Revit.DB.Dimension.Value
zh: 尺寸标注、标注
source: html/883a5cec-31db-39c1-2745-210a45d67374.htm
---
# Autodesk.Revit.DB.Dimension.Value Property

**中文**: 尺寸标注、标注

The value of the dimension.

## Syntax (C#)
```csharp
public Nullable<double> Value { get; }
```

## Remarks
This nullable property will not have a value for spot dimensions
or for linear dimensions with more than one segment.

