---
kind: property
id: P:Autodesk.Revit.DB.BoundingBoxContainsPointFilter.Tolerance
source: html/c5f8cb9d-75ea-8e8d-b985-5318a06921bf.htm
---
# Autodesk.Revit.DB.BoundingBoxContainsPointFilter.Tolerance Property

Allows control over the match criteria by using a tolerance in the geometry comparison. It is suggested to use this in cases where trivial differences should be considered when matching elements.

## Syntax (C#)
```csharp
public double Tolerance { get; set; }
```

## Remarks
By default this is set to zero, but depending on your units of measure and how close objects may be, it is advised to set this to something more realistic.
 If the tolerance is positive, the point may lie up to the tolerance amount outside the outline to be matched.
 If the tolerance is negative, the point must lie at least the tolerance amount inside the outline to be matched.

