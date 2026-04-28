---
kind: property
id: P:Autodesk.Revit.DB.DividedPath.BeginningIndent
source: html/a8c752cd-7b13-a671-b6c6-125371e19b50.htm
---
# Autodesk.Revit.DB.DividedPath.BeginningIndent Property

The beginningIndent is an offset distance from the beginning of the
 first curve that determines the beginning of the range over which
 the layout is applied.
 The measurement type determines how the distance is measured.

## Syntax (C#)
```csharp
public double BeginningIndent { get; set; }
```

## Remarks
BeginningIndent and endIndent are not allowed to overlap

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for beginningIndent must be between 0 and 30000 feet.
 -or-
 When setting this property: beginningIndent overlaps with endIndent

