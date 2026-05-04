---
kind: method
id: M:Autodesk.Revit.DB.UnitUtils.IsUnit(Autodesk.Revit.DB.ForgeTypeId)
source: html/da854415-776c-ecf2-6d18-22d343fb5ebc.htm
---
# Autodesk.Revit.DB.UnitUtils.IsUnit Method

Checks whether a ForgeTypeId identifies a unit.

## Syntax (C#)
```csharp
public static bool IsUnit(
	ForgeTypeId unitTypeId
)
```

## Parameters
- **unitTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - The identifier to check.

## Returns
True if the ForgeTypeId identifies a unit, false otherwise.

## Remarks
The UnitTypeId class offers unit identifiers.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

