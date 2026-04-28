---
kind: property
id: P:Autodesk.Revit.DB.DividedPath.EndIndent
source: html/0da081e7-20b9-0def-2c76-4cd8cb690823.htm
---
# Autodesk.Revit.DB.DividedPath.EndIndent Property

The endIndent is an offset distance from the end of the
 last curve that determines the end of the range over which
 the layout is applied.
 The measurement type determines how the distance is measured.

## Syntax (C#)
```csharp
public double EndIndent { get; set; }
```

## Remarks
BeginningIndent and endIndent are not allowed to overlap

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for endIndent must be between 0 and 30000 feet.
 -or-
 When setting this property: endIndent overlaps with beginningIndent

