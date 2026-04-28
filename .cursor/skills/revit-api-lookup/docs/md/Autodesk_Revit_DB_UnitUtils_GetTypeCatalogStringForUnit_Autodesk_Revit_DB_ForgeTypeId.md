---
kind: method
id: M:Autodesk.Revit.DB.UnitUtils.GetTypeCatalogStringForUnit(Autodesk.Revit.DB.ForgeTypeId)
source: html/d97c331b-2aca-3d09-48ed-d22c2281e595.htm
---
# Autodesk.Revit.DB.UnitUtils.GetTypeCatalogStringForUnit Method

Gets the string used in type catalogs to identify a given unit.

## Syntax (C#)
```csharp
public static string GetTypeCatalogStringForUnit(
	ForgeTypeId unitTypeId
)
```

## Parameters
- **unitTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the unit.

## Returns
The type catalog string, or an empty string if the unit cannot be used in type catalogs.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - unitTypeId is not a unit identifier. See UnitUtils.IsUnit(ForgeTypeId) and UnitUtils.GetUnitTypeId(DisplayUnitType).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

