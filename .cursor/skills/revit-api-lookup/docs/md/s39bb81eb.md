---
kind: method
id: M:Autodesk.Revit.DB.FormatOptions.GetSymbolTypeId
source: html/f02c0f51-3519-e04e-ef5a-25ae11e0acc1.htm
---
# Autodesk.Revit.DB.FormatOptions.GetSymbolTypeId Method

Gets the identifier of the symbol indicating the unit quantifying the value.

## Syntax (C#)
```csharp
public ForgeTypeId GetSymbolTypeId()
```

## Returns
The symbol identifier. An empty identifier string indicates no symbol.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - UseDefault is true in this FormatOptions.

