---
kind: property
id: P:Autodesk.Revit.DB.Dimension.TextPosition
zh: 尺寸标注、标注
source: html/2a3b8401-48c9-8425-1f98-b142babdf0a2.htm
---
# Autodesk.Revit.DB.Dimension.TextPosition Property

**中文**: 尺寸标注、标注

The position of the dimension text's drag point.

## Syntax (C#)
```csharp
public XYZ TextPosition { get; set; }
```

## Remarks
This property is not applicable to all dimensions.
 For example, it is not available for spot slope dimensions, multi-segments dimensions,
 dimensions using equality formula, and when dimension style is ordinate. If the position is not applicable, this property throws InvalidOperationException.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when:
 SpotDimension style type is SpotSlope. Using equality formula. Dimension style is ordinate. 
 -or-
 Thrown when:
 SpotDimension has more than one segments. 
 -or-

