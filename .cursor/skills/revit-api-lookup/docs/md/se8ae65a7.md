---
kind: method
id: M:Autodesk.Revit.DB.Analysis.EnergyDataSettings.GetBuildingConstructionSetElementId(Autodesk.Revit.DB.Document)
source: html/73394ff4-98f4-f782-061b-a3fc02e1352c.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.GetBuildingConstructionSetElementId Method

Id of the building construction set.

## Syntax (C#)
```csharp
public static ElementId GetBuildingConstructionSetElementId(
	Document ccda
)
```

## Parameters
- **ccda** (`Autodesk.Revit.DB.Document`)

## Returns
Returns the id of the building construction set.

## Remarks
The building construction set is the default
 project construction set used when spaces are not assigned a
 construction.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

