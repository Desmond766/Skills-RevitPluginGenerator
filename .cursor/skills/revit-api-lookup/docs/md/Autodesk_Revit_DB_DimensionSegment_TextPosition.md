---
kind: property
id: P:Autodesk.Revit.DB.DimensionSegment.TextPosition
source: html/0f0ec861-b61f-e63d-490c-ef2967782963.htm
---
# Autodesk.Revit.DB.DimensionSegment.TextPosition Property

The position of the dimension text's drag point.

## Syntax (C#)
```csharp
public XYZ TextPosition { get; set; }
```

## Remarks
This property is not applicable to all dimensions.
For example, it is not available for spot dimensions,
dimensions using equality formula, and when dimension style is ordinate. If the position is not applicable, this property returns NULL
and will not allow setting a value.

## Exceptions
- **Autodesk.Revit.Exceptions.ApplicationException** - Thrown when the dimension text is unavailable.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when:
 The dimension text is a SpotElevation When using equality formula. When dimension style is ordinate. .

