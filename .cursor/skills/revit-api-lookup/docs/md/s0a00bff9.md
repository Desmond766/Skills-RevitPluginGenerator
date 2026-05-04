---
kind: method
id: M:Autodesk.Revit.DB.Dimension.ResetTextPosition
zh: 尺寸标注、标注
source: html/2e4a13c9-1fc0-c1a4-6d85-1dcbc65b3e22.htm
---
# Autodesk.Revit.DB.Dimension.ResetTextPosition Method

**中文**: 尺寸标注、标注

Resets the text position of the dimension to the initial position determined by its type and parameters.

## Syntax (C#)
```csharp
public void ResetTextPosition()
```

## Remarks
The initial point is the text position determined by the type and parameters of the dimension.
 This property is for use with single-segment dimensions only.
 For multi-segment dimensions use the corresponding method of the
 DimensionSegment class.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when:
 SpotDimension has more than one segments.

