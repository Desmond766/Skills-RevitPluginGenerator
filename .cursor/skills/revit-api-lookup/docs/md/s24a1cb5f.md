---
kind: method
id: M:Autodesk.Revit.DB.FormatOptions.IsValidSymbol(Autodesk.Revit.DB.ForgeTypeId)
source: html/76dcb7fb-0b2a-2dcf-2df5-d8c0ac4643f2.htm
---
# Autodesk.Revit.DB.FormatOptions.IsValidSymbol Method

Checks whether a symbol is valid for the unit in this FormatOptions.

## Syntax (C#)
```csharp
public bool IsValidSymbol(
	ForgeTypeId symbolTypeId
)
```

## Parameters
- **symbolTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the symbol to check.

## Returns
True if the symbol is valid, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - UseDefault is true in this FormatOptions.

