---
kind: method
id: M:Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckBuildingType(Autodesk.Revit.DB.Analysis.gbXMLBuildingType)
source: html/5d9ab4ae-9c43-c7b7-f851-39f04ab95989.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckBuildingType Method

Checks that the building type falls within an appropriate range.

## Syntax (C#)
```csharp
public static bool CheckBuildingType(
	gbXMLBuildingType buildingType
)
```

## Parameters
- **buildingType** (`Autodesk.Revit.DB.Analysis.gbXMLBuildingType`) - The building type to be checked.

## Returns
True if the building type falls within an appropriate range, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

