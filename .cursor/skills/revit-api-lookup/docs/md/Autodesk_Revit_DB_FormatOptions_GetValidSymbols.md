---
kind: method
id: M:Autodesk.Revit.DB.FormatOptions.GetValidSymbols
source: html/21207530-9582-98bf-83b1-4757db96a34f.htm
---
# Autodesk.Revit.DB.FormatOptions.GetValidSymbols Method

Gets the identifiers of all valid symbols for the unit in this FormatOptions.

## Syntax (C#)
```csharp
public IList<ForgeTypeId> GetValidSymbols()
```

## Returns
Identifiers of the valid symbols.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - UseDefault is true in this FormatOptions.

