---
kind: property
id: P:Autodesk.Revit.DB.FormatOptions.UseDigitGrouping
source: html/76d95bbc-e2d6-8373-b453-82bab482d0f5.htm
---
# Autodesk.Revit.DB.FormatOptions.UseDigitGrouping Property

Indicates if digit grouping symbols should be displayed.

## Syntax (C#)
```csharp
public bool UseDigitGrouping { get; set; }
```

## Remarks
When UseDigitGrouping is true, digit grouping symbols (i.e.
 thousands separators) will be displayed when needed. For example,
 123456789.00 may be displayed as 123,456,789.00. The precise
 display is determined by the DigitGroupingSymbol and
 DigitGroupingAmount properties of the Units class.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - UseDefault is true in this FormatOptions.

