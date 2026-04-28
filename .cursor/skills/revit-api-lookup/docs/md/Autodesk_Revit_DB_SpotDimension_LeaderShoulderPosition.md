---
kind: property
id: P:Autodesk.Revit.DB.SpotDimension.LeaderShoulderPosition
source: html/cb42a9d3-8a01-433c-46fb-2e390218f67a.htm
---
# Autodesk.Revit.DB.SpotDimension.LeaderShoulderPosition Property

Position of spot dimension's leader shoulder point.

## Syntax (C#)
```csharp
public XYZ LeaderShoulderPosition { get; set; }
```

## Remarks
Setting of this property also affects LeaderEndPosition and TextPosition.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Dimension must have leader.
 -or-
 Dimension's leader must have shoulder.
 -or-
 Thrown when:
 SpotDimension style type is SpotSlope. Using equality formula. Dimension style is ordinate. 
 -or-
 The dimension is a SpotSlope or has no leader or leader has no shoulder.

