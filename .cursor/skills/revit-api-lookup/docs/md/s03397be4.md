---
kind: method
id: M:Autodesk.Revit.DB.FormatOptions.IsValidForSpec(Autodesk.Revit.DB.ForgeTypeId)
source: html/299216ba-fd6d-4e23-e1e9-3d34298ed63a.htm
---
# Autodesk.Revit.DB.FormatOptions.IsValidForSpec Method

Checks whether this FormatOptions is valid for a given spec.

## Syntax (C#)
```csharp
public bool IsValidForSpec(
	ForgeTypeId specTypeId
)
```

## Parameters
- **specTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the spec.

## Returns
True if the FormatOptions is valid, false otherwise.

## Remarks
The FormatOptions is valid if UseDefault is true or if the unit in
 the FormatOptions is valid for the spec. See
 UnitUtils.IsValidUnit(ForgeTypeId, ForgeTypeId) and
 UnitUtils.GetValidUnits(ForgeTypeId) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - specTypeId is not a measurable spec identifier. See UnitUtils.IsMeasurableSpec(ForgeTypeId).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

