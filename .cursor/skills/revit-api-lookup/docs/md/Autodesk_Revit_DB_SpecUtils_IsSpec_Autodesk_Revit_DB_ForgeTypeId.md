---
kind: method
id: M:Autodesk.Revit.DB.SpecUtils.IsSpec(Autodesk.Revit.DB.ForgeTypeId)
source: html/acf7b145-40bc-cb05-c03a-bfbdb902e3ee.htm
---
# Autodesk.Revit.DB.SpecUtils.IsSpec Method

Checks whether a ForgeTypeId identifies a spec.

## Syntax (C#)
```csharp
public static bool IsSpec(
	ForgeTypeId specTypeId
)
```

## Parameters
- **specTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - The identifier to check.

## Returns
True if the ForgeTypeId identifies a spec, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

