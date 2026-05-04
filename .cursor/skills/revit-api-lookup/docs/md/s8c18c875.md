---
kind: method
id: M:Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckBuildingOperatingSchedule(Autodesk.Revit.DB.Analysis.gbXMLBuildingOperatingSchedule)
source: html/1cad3583-7bbc-ec0e-258e-f9d23464dee4.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckBuildingOperatingSchedule Method

Checks that the building operating schedule falls within an appropriate range.

## Syntax (C#)
```csharp
public static bool CheckBuildingOperatingSchedule(
	gbXMLBuildingOperatingSchedule buildingOperatingSchedule
)
```

## Parameters
- **buildingOperatingSchedule** (`Autodesk.Revit.DB.Analysis.gbXMLBuildingOperatingSchedule`) - The building operating schedule to be checked.

## Returns
True if the building operating schedule falls within an appropriate range, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

