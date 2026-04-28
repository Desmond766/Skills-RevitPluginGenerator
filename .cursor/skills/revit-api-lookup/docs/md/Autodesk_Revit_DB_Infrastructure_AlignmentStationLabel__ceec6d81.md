---
kind: type
id: T:Autodesk.Revit.DB.Infrastructure.AlignmentStationLabel
source: html/5c51c34b-8b34-99fe-d8c6-b6f1ba7caba7.htm
---
# Autodesk.Revit.DB.Infrastructure.AlignmentStationLabel

Represents an object which provides access to a specialized Revit annotation element 
 used for labeling Alignment stations.

## Syntax (C#)
```csharp
public class AlignmentStationLabel
```

## Remarks
The element is a SpotDimension .
 The element's category is OST_AlignmentStationLabels or, 
 if in a set of labels, OST_AlignmentStationLabelSets .
 The element's type is a SpotDimensionType 
 with DimensionStyleType equal to AlignmentStationLabel .
 The element's Origin is a point on the tessellated representation of an alignment.
 To get the precise point on the alignment's curve, use GetPointAtStation(Double) 
 with input obtained from Station .

