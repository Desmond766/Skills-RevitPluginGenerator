---
kind: property
id: P:Autodesk.Revit.DB.DimensionSegment.LeaderEndPosition
source: html/3cc4983a-3d57-95d9-71f9-39144254c839.htm
---
# Autodesk.Revit.DB.DimensionSegment.LeaderEndPosition Property

The position of the dimension leader end point.

## Syntax (C#)
```csharp
public XYZ LeaderEndPosition { get; set; }
```

## Remarks
This property is not applicable to all dimensions.
For example, it is not available for spot dimensions,
dimensions using equality formula, and when dimension style is ordinate. If the position is not applicable, this property returns NULL
and will not allow setting a value.

## Exceptions
- **Autodesk.Revit.Exceptions.ApplicationException** - Thrown when the dimension text is unavailable.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when:
 The dimension text is a SpotElevation When using equality formula. When dimension style is ordinate.

