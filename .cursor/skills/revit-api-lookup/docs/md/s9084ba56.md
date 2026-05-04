---
kind: property
id: P:Autodesk.Revit.DB.ColorFillScheme.IsByRange
source: html/2e6a3c32-a3f8-a6dd-6552-7ba7a901d9fb.htm
---
# Autodesk.Revit.DB.ColorFillScheme.IsByRange Property

Represents if the parameter values in entries are treated as value range or not.

## Syntax (C#)
```csharp
public bool IsByRange { get; set; }
```

## Remarks
Notes: Only numeric parameter values could be treated as by range. There will exist at least two entries if the scheme is by range,
 and the first entry value should be always Int.MinValue or -Double.MaxValue. The entries will always be sorted by ascending in the scheme if it is by range.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The scheme entries cannot be explained by range.

