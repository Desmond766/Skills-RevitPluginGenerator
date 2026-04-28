---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetElevationProfile(Autodesk.Revit.DB.Wall)
source: html/6e7a864e-7ac4-8d06-aba6-13ba45fe0776.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetElevationProfile Method

Obtains the curve loops which bound the wall's elevation profile.

## Syntax (C#)
```csharp
public static IList<CurveLoop> GetElevationProfile(
	Wall pVWall
)
```

## Parameters
- **pVWall** (`Autodesk.Revit.DB.Wall`) - The wall.

## Returns
The collection of curve loops.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The wall does not have an elevation profile.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

