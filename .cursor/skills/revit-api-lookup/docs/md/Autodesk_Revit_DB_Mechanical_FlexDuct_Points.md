---
kind: property
id: P:Autodesk.Revit.DB.Mechanical.FlexDuct.Points
source: html/7273b1b6-337b-e65c-95bb-5639467d98c8.htm
---
# Autodesk.Revit.DB.Mechanical.FlexDuct.Points Property

The points of the flex duct.

## Syntax (C#)
```csharp
public IList<XYZ> Points { get; set; }
```

## Remarks
This property is used to retrieve the points of flex duct, including the end points.
If the end points are changed, the connection will be maintained by Revit automatically. 
The set operation will fail if the modification makes the connection invalid.

