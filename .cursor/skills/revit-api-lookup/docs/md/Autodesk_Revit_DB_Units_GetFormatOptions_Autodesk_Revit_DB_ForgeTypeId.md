---
kind: method
id: M:Autodesk.Revit.DB.Units.GetFormatOptions(Autodesk.Revit.DB.ForgeTypeId)
source: html/a2817756-7d35-f9b9-0daf-172010b66ed0.htm
---
# Autodesk.Revit.DB.Units.GetFormatOptions Method

Gets the default FormatOptions for a spec.

## Syntax (C#)
```csharp
public FormatOptions GetFormatOptions(
	ForgeTypeId specTypeId
)
```

## Parameters
- **specTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the spec.

## Returns
A copy of the FormatOptions.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - specTypeId is not a measurable spec identifier. See UnitUtils.IsMeasurableSpec(ForgeTypeId).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

