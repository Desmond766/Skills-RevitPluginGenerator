---
kind: method
id: M:Autodesk.Revit.DB.UnitUtils.IsValidUnit(Autodesk.Revit.DB.ForgeTypeId,Autodesk.Revit.DB.ForgeTypeId)
source: html/011d8e94-17c5-e29c-2642-b137b9c6894d.htm
---
# Autodesk.Revit.DB.UnitUtils.IsValidUnit Method

Checks whether a unit is valid for a given measurable spec.

## Syntax (C#)
```csharp
public static bool IsValidUnit(
	ForgeTypeId specTypeId,
	ForgeTypeId unitTypeId
)
```

## Parameters
- **specTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the measurable spec.
- **unitTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the unit to check.

## Returns
True if the unit is valid, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - specTypeId is not a measurable spec identifier. See UnitUtils.IsMeasurableSpec(ForgeTypeId).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

