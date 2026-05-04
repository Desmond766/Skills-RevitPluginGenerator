---
kind: method
id: M:Autodesk.Revit.DB.FormatOptions.CanSuppressTrailingZeros
source: html/f8cbf191-8a6a-ab05-e1d9-95ef31373a07.htm
---
# Autodesk.Revit.DB.FormatOptions.CanSuppressTrailingZeros Method

Checks whether trailing zeros can be suppressed for the display unit in this FormatOptions.

## Syntax (C#)
```csharp
public bool CanSuppressTrailingZeros()
```

## Returns
True if trailing zeros can be suppressed, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - UseDefault is true in this FormatOptions.

