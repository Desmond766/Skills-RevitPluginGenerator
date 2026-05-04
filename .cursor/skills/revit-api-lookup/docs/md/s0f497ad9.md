---
kind: method
id: M:Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckBuildingHVACSystem(Autodesk.Revit.DB.Analysis.gbXMLBuildingHVACSystem)
source: html/54e37f5e-e7c7-1eb6-622e-f271775b8716.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckBuildingHVACSystem Method

Checks that the building HVAC system falls within an appropriate range.

## Syntax (C#)
```csharp
public static bool CheckBuildingHVACSystem(
	gbXMLBuildingHVACSystem buildingHVACSystem
)
```

## Parameters
- **buildingHVACSystem** (`Autodesk.Revit.DB.Analysis.gbXMLBuildingHVACSystem`) - The building HVAC system to be checked.

## Returns
True if the building HVAC system falls within an appropriate range, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

