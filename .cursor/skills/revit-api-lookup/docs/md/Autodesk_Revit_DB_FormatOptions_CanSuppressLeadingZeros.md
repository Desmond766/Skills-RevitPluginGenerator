---
kind: method
id: M:Autodesk.Revit.DB.FormatOptions.CanSuppressLeadingZeros
source: html/60307349-326c-bfc6-3126-f1a5cdd0cb22.htm
---
# Autodesk.Revit.DB.FormatOptions.CanSuppressLeadingZeros Method

Checks whether leading zeros can be suppressed for the display unit in this FormatOptions.

## Syntax (C#)
```csharp
public bool CanSuppressLeadingZeros()
```

## Returns
True if leading zeros can be suppressed, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - UseDefault is true in this FormatOptions.

