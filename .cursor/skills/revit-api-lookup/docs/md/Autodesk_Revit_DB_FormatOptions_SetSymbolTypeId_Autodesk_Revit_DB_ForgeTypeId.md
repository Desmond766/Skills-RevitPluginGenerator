---
kind: method
id: M:Autodesk.Revit.DB.FormatOptions.SetSymbolTypeId(Autodesk.Revit.DB.ForgeTypeId)
source: html/d0d5b77a-3fdd-b6cc-9d3a-9fc82a76d71f.htm
---
# Autodesk.Revit.DB.FormatOptions.SetSymbolTypeId Method

Sets the symbol that should be displayed to indicate the unit quantifying the value.

## Syntax (C#)
```csharp
public void SetSymbolTypeId(
	ForgeTypeId symbolTypeId
)
```

## Parameters
- **symbolTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - The symbol identifier. An empty identifier string indicates no symbol.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - symbolTypeId is not a valid symbol for the unit in this FormatOptions.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - UseDefault is true in this FormatOptions.

