---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsRunType.RiserThickness
source: html/c1499b8a-f969-18f0-c7fd-b42609e5603a.htm
---
# Autodesk.Revit.DB.Architecture.StairsRunType.RiserThickness Property

The thickness of the risers.

## Syntax (C#)
```csharp
public double RiserThickness { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for length must be greater than 0 and no more than 30000 feet.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The run type has no riser so the data being set is not applicable.

