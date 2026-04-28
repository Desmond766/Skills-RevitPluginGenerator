---
kind: property
id: P:Autodesk.Revit.DB.BoundingBoxIsInsideFilter.Tolerance
source: html/c54d7e5e-209b-82c4-4723-067a8668a674.htm
---
# Autodesk.Revit.DB.BoundingBoxIsInsideFilter.Tolerance Property

Allows control over the match criteria by using a tolerance in the geometry comparison. It is suggested to use this in cases where trivial differences should be considered when matching elements.

## Syntax (C#)
```csharp
public double Tolerance { get; set; }
```

## Remarks
By default this is set to zero, but depending on your units of measure and how close objects may be, it is advised to set this to something more realistic.
 If the tolerance is positive, the iterated element's Outline may extend the tolerance distance outside of the given Outline in each coordinate to be a match.
 If the tolerance is negative, the iterated element's Outline must lie at least the tolerance distance inside the given Outline in each coordinate to be a match.

