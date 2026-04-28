---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.HasElevationProfile(Autodesk.Revit.DB.Wall)
source: html/ff3308db-ae11-d118-5f1e-40e4fdbee72d.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.HasElevationProfile Method

Identifies if the wall has a sketched elevation profile.

## Syntax (C#)
```csharp
public static bool HasElevationProfile(
	Wall pVWall
)
```

## Parameters
- **pVWall** (`Autodesk.Revit.DB.Wall`) - The wall.

## Returns
True if the wall has a sketch elevation profile, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

