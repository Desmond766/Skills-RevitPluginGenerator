---
kind: method
id: M:Autodesk.Revit.DB.LabelUtils.GetLabelForSpec(Autodesk.Revit.DB.ForgeTypeId)
source: html/5f0e82b9-cf62-062d-5136-3c4032cca766.htm
---
# Autodesk.Revit.DB.LabelUtils.GetLabelForSpec Method

Gets the user-visible name for a spec.

## Syntax (C#)
```csharp
public static string GetLabelForSpec(
	ForgeTypeId specTypeId
)
```

## Parameters
- **specTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the spec to get the user-visible name.

## Remarks
The name is obtained in the current Revit language.
 If the given identifier is a category, this method returns the name
 of the Family Type spec with that category, e.g. "Family Type: Walls".

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given identifier is neither a spec nor a category.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

