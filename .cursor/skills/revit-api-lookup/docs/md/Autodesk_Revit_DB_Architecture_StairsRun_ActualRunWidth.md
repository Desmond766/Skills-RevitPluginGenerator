---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsRun.ActualRunWidth
source: html/bdf55936-55bd-fc08-ffb4-8636f9523e9d.htm
---
# Autodesk.Revit.DB.Architecture.StairsRun.ActualRunWidth Property

Specifies the value of the tread width excluding the width of independent side supports.

## Syntax (C#)
```csharp
public double ActualRunWidth { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for runWidth must be greater than 0 and no more than 30000 feet.
 -or-
 When setting this property: The runWidth is too small or too large to be used as actual run width, probably it
 doesn't satisfy the layout generation restriction of the stairs run.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The stairs run is sketched so the data being set is not applicable.

