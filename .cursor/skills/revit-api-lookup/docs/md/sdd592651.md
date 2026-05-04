---
kind: property
id: P:Autodesk.Revit.DB.Opening.IsRectBoundary
source: html/572ba4b4-d9cf-fecc-3066-efb53000db3d.htm
---
# Autodesk.Revit.DB.Opening.IsRectBoundary Property

Retrieves the information whether the opening has a rectangular boundary.

## Syntax (C#)
```csharp
public bool IsRectBoundary { get; }
```

## Remarks
If the opening has a rectangular boundary, we can get the geometry information from BoundaryRect property.
Otherwise we should get the geometry information from BoundaryCurves property.

