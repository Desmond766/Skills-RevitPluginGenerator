---
kind: method
id: M:Autodesk.Revit.DB.UnitUtils.IsSymbol(Autodesk.Revit.DB.ForgeTypeId)
source: html/c3c2814f-2634-9321-5bf1-193b392367d1.htm
---
# Autodesk.Revit.DB.UnitUtils.IsSymbol Method

Checks whether a ForgeTypeId identifies a symbol.

## Syntax (C#)
```csharp
public static bool IsSymbol(
	ForgeTypeId symbolTypeId
)
```

## Parameters
- **symbolTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - The identifier to check.

## Returns
True if the ForgeTypeId identifies a symbol, false otherwise.

## Remarks
The SymbolTypeId class offers symbol identifiers.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

