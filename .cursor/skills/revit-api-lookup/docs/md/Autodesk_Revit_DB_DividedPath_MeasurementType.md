---
kind: property
id: P:Autodesk.Revit.DB.DividedPath.MeasurementType
source: html/7fe32666-bf90-1624-0b0d-c49569f49d80.htm
---
# Autodesk.Revit.DB.DividedPath.MeasurementType Property

The measurement type determines how distances are calculated.
 Either along a straight line between two points ('ChordLength')
 or along the segment of the path that connects them. ('SegmentLength').

## Syntax (C#)
```csharp
public DividedPathMeasurementType MeasurementType { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: Invalid measurementType
 -or-
 When setting this property: A value passed for an enumeration argument is not a member of that enumeration

