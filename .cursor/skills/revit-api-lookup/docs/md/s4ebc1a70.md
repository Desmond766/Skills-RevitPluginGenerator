---
kind: method
id: M:Autodesk.Revit.DB.FormatOptions.CanHaveSymbol
source: html/4b7b3e24-5c17-78ab-9215-6a4c0b361c93.htm
---
# Autodesk.Revit.DB.FormatOptions.CanHaveSymbol Method

Checks whether a symbol can be specified to display the unit in this FormatOptions.

## Syntax (C#)
```csharp
public bool CanHaveSymbol()
```

## Returns
True if a symbol can be specified, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - UseDefault is true in this FormatOptions.

