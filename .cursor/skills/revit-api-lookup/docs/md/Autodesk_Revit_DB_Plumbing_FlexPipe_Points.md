---
kind: property
id: P:Autodesk.Revit.DB.Plumbing.FlexPipe.Points
source: html/8aac116b-26f3-061a-6cff-fd0bcb0be110.htm
---
# Autodesk.Revit.DB.Plumbing.FlexPipe.Points Property

The points of the flex pipe.

## Syntax (C#)
```csharp
public IList<XYZ> Points { get; set; }
```

## Remarks
This property is used to retrieve the points of flex pipe, including the end points.
If the end points are changed, the connection will be maintained by Revit automatically. 
The set operation will fail if the modification makes the connection invalid.

