---
kind: property
id: P:Autodesk.Revit.DB.Analysis.MassSurfaceData.SurfaceDataSource
source: html/2f9126ea-17e4-c221-40f8-e430dfae5262.htm
---
# Autodesk.Revit.DB.Analysis.MassSurfaceData.SurfaceDataSource Property

Indicates whether the MassSurfaceData properties are driven by the EnergyDataSettings
 of the Document or are overridden for the surface.

## Syntax (C#)
```csharp
public MassSurfaceDataSource SurfaceDataSource { get; set; }
```

## Remarks
The Construction property is not governed by this setting and
 has a separate value to indicate if it is to be synchronized
 with EnergyDataSettings.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The surface data source does not fall within an appropriate range.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

