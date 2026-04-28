---
kind: property
id: P:Autodesk.Revit.DB.Dimension.ValueString
zh: 尺寸标注、标注
source: html/8608426e-2490-158c-f52b-f79d88f793f6.htm
---
# Autodesk.Revit.DB.Dimension.ValueString Property

**中文**: 尺寸标注、标注

The dimension value as a user visible string.

## Syntax (C#)
```csharp
public string ValueString { get; }
```

## Remarks
This property always return Nothing nullptr a null reference ( Nothing in Visual Basic) if this is a spot dimension,
or it is a linear dimension with more than one segments.

