---
kind: property
id: P:Autodesk.Revit.DB.Analysis.MassSurfaceData.SillHeight
source: html/03f384b6-7a50-15c9-aed0-ab39d18c6b52.htm
---
# Autodesk.Revit.DB.Analysis.MassSurfaceData.SillHeight Property

The height above the level where the bottoms of auto-generated windows will be located.

## Syntax (C#)
```csharp
public double SillHeight { get; set; }
```

## Remarks
Will be accurate unless the target glazing percentage cannot be achieved using this height.
 In that case, the sillHeight will be ignored and windows will be created below this height.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The sill height is less than zero.

