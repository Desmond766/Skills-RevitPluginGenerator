---
kind: method
id: M:Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckBuildingEnvelope(Autodesk.Revit.DB.Analysis.gbXMLExportBuildingEnvelope)
source: html/1168066f-110b-cbcb-b983-12fdb7f44906.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckBuildingEnvelope Method

Checks that the building envelope determination method falls within an appropriate range.

## Syntax (C#)
```csharp
public static bool CheckBuildingEnvelope(
	gbXMLExportBuildingEnvelope determinationMethod
)
```

## Parameters
- **determinationMethod** (`Autodesk.Revit.DB.Analysis.gbXMLExportBuildingEnvelope`) - The building envelope determination method to be checked.

## Returns
True if the building envelope determination method falls within an appropriate range, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

