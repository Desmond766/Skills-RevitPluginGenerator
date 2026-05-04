---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyDataSettings.BuildingOperatingSchedule
source: html/371fc47a-dedc-d50b-1a00-3c9a6d9e7f2b.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.BuildingOperatingSchedule Property

The operating schedule of the building used for conceptual model energy calculations.

## Syntax (C#)
```csharp
public gbXMLBuildingOperatingSchedule BuildingOperatingSchedule { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The building operating schedule does not fall within an appropriate range.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

