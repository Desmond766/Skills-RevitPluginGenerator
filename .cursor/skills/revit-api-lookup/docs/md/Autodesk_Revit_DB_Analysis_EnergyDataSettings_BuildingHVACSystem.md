---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyDataSettings.BuildingHVACSystem
source: html/a587f6f0-b3e4-fc53-f0ca-0b168e21eb69.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.BuildingHVACSystem Property

The type of HVAC system used by the building for conceptual model energy calculations.

## Syntax (C#)
```csharp
public gbXMLBuildingHVACSystem BuildingHVACSystem { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The building HVAC system does not fall within an appropriate range.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

