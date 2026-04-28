---
kind: property
id: P:Autodesk.Revit.DB.BoundingBoxIntersectsFilter.Tolerance
source: html/2c9269cc-09c6-576a-ddf9-7f0599088944.htm
---
# Autodesk.Revit.DB.BoundingBoxIntersectsFilter.Tolerance Property

Allows control over the match criteria by using a tolerance in the geometry comparison. It is suggested to use this in cases where trivial differences should be considered when matching elements.

## Syntax (C#)
```csharp
public double Tolerance { get; set; }
```

## Remarks
By default this is set to zero, but depending on your units of measure and how close objects may be, it is advised to set this to something more realistic.
 If the tolerance is positive, the outlines may be separated by the tolerance distance in each coordinate.
 If the tolerance is negative, the outlines must overlap by at least the tolerance distance in each coordinate.

