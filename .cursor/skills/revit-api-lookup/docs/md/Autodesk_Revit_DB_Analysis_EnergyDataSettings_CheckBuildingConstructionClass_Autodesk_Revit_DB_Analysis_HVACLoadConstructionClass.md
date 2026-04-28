---
kind: method
id: M:Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckBuildingConstructionClass(Autodesk.Revit.DB.Analysis.HVACLoadConstructionClass)
source: html/40d11195-0a0e-8867-9d92-74288ddc88ee.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckBuildingConstructionClass Method

Checks that the building construction class falls within an appropriate range.

## Syntax (C#)
```csharp
public static bool CheckBuildingConstructionClass(
	HVACLoadConstructionClass buildingConstructionClass
)
```

## Parameters
- **buildingConstructionClass** (`Autodesk.Revit.DB.Analysis.HVACLoadConstructionClass`) - The building construction class to be checked.

## Returns
True if the building construction class falls within an appropriate range, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

