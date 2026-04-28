---
kind: property
id: P:Autodesk.Revit.DB.DividedPath.MaximumDistance
source: html/b83aaacd-f4c1-e834-3bf8-15a9a10a4de8.htm
---
# Autodesk.Revit.DB.DividedPath.MaximumDistance Property

The maximum distance is used when the layout is set to 'MaximumSpacing'.
 When that layout rule is used the distance between points will not exceed this value.
 The measurement type determines how the distance is measured.

## Syntax (C#)
```csharp
public double MaximumDistance { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The maximumDistance is too small.

