---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyDataSettings.SliverSpaceTolerance
source: html/dbca870f-989e-1134-5ef9-b6a5b47c6508.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.SliverSpaceTolerance Property

Used for Detailed GreenBuildingXML export.
 This value is used to identify sliver spaces, i.e. spaces bounded by parallel surfaces belonging to different rooms.

## Syntax (C#)
```csharp
public double SliverSpaceTolerance { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The sliver space tolerance is less than zero.

