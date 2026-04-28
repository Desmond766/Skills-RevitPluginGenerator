---
kind: method
id: M:Autodesk.Revit.DB.UnitUtils.GetTypeCatalogStringForSpec(Autodesk.Revit.DB.ForgeTypeId)
source: html/734489b8-00fa-c522-daf9-a9a00063aa37.htm
---
# Autodesk.Revit.DB.UnitUtils.GetTypeCatalogStringForSpec Method

Gets the string used in type catalogs to identify a given measurable spec.

## Syntax (C#)
```csharp
public static string GetTypeCatalogStringForSpec(
	ForgeTypeId specTypeId
)
```

## Parameters
- **specTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the measurable spec.

## Returns
The type catalog string, or an empty string if the measurable spec cannot be used in type catalogs.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - specTypeId is not a measurable spec identifier. See UnitUtils.IsMeasurableSpec(ForgeTypeId).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

