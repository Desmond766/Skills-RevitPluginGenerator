---
kind: property
id: P:Autodesk.Revit.DB.Architecture.ContinuousRailType.FilletRadius
source: html/c3ca4cc4-39a6-90a7-792e-9247bd55d48b.htm
---
# Autodesk.Revit.DB.Architecture.ContinuousRailType.FilletRadius Property

The fillet radius of the rail join.

## Syntax (C#)
```csharp
public double FilletRadius { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for filletRadius must be between 0 and 30000 feet.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The join option of the rail is not fillet so the data being set is not applicable.

