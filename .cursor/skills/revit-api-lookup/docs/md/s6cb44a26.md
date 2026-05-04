---
kind: method
id: M:Autodesk.Revit.DB.UnitUtils.GetValidUnits(Autodesk.Revit.DB.ForgeTypeId)
source: html/5e7af690-b8cc-3576-c09d-6e7a8e1fdfd1.htm
---
# Autodesk.Revit.DB.UnitUtils.GetValidUnits Method

Gets the identifiers of all valid units for a given measurable spec.

## Syntax (C#)
```csharp
public static IList<ForgeTypeId> GetValidUnits(
	ForgeTypeId specTypeId
)
```

## Parameters
- **specTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the measurable spec.

## Returns
Identifiers of the valid units.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - specTypeId is not a measurable spec identifier. See UnitUtils.IsMeasurableSpec(ForgeTypeId).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

