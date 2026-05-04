---
kind: method
id: M:Autodesk.Revit.DB.UnitUtils.GetDiscipline(Autodesk.Revit.DB.ForgeTypeId)
source: html/77c58c44-0d8d-c10f-b6e7-2be9a25bbb1e.htm
---
# Autodesk.Revit.DB.UnitUtils.GetDiscipline Method

Gets the discipline for a given measurable spec.

## Syntax (C#)
```csharp
public static ForgeTypeId GetDiscipline(
	ForgeTypeId specTypeId
)
```

## Parameters
- **specTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the measurable spec.

## Returns
Identifier of the discipline.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - specTypeId is not a measurable spec identifier. See UnitUtils.IsMeasurableSpec(ForgeTypeId).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

