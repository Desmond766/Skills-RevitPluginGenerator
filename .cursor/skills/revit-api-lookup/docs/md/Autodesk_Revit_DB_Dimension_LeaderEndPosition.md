---
kind: property
id: P:Autodesk.Revit.DB.Dimension.LeaderEndPosition
zh: 尺寸标注、标注
source: html/cf75655f-f779-5c31-5ea5-dc27839c46d5.htm
---
# Autodesk.Revit.DB.Dimension.LeaderEndPosition Property

**中文**: 尺寸标注、标注

The position of the dimension's leader end point.

## Syntax (C#)
```csharp
public XYZ LeaderEndPosition { get; set; }
```

## Remarks
This property is not applicable to all dimensions.
 For example, it is not available for spot slope dimensions, multi-segments dimensions,
 dimensions using equality formula, and when dimension style is ordinate. If the position is not applicable, this property throws InvalidOperationException. Notes for SpotDimension:
 This property throws InvalidOperationException if dimension has no leader. Setting of this property works differently for leader with and without shoulder. If leader has shoulder, setting is limited by points on line between leader end and shoulder points (projected point is used). Setting of this property also affects TextPosition.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Dimension must have leader.
 -or-
 Thrown when:
 SpotDimension style type is SpotSlope. Using equality formula. Dimension style is ordinate. 
 -or-
 Thrown when:
 SpotDimension has more than one segments. 
 -or-

