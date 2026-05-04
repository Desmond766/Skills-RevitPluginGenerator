---
kind: method
id: M:Autodesk.Revit.DB.LabelUtils.GetLabelForSymbol(Autodesk.Revit.DB.ForgeTypeId)
source: html/d8dc0d86-c548-89ba-da65-3f3a9b2f9ec8.htm
---
# Autodesk.Revit.DB.LabelUtils.GetLabelForSymbol Method

Gets the user-visible name for a symbol.

## Syntax (C#)
```csharp
public static string GetLabelForSymbol(
	ForgeTypeId symbolTypeId
)
```

## Parameters
- **symbolTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the symbol to get the user-visible name.

## Remarks
The name is obtained in the current Revit language.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Symbol must have a definition.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

