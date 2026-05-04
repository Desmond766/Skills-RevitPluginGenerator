---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsType.RightLateralOffset
source: html/f98a476d-ba35-5967-c119-2d64df43a900.htm
---
# Autodesk.Revit.DB.Architecture.StairsType.RightLateralOffset Property

The offset for the right support from the edge of the run in a horizontal direction.

## Syntax (C#)
```csharp
public double RightLateralOffset { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for offset must be between 0 and 30000 feet.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The right support style is not carriage(open), so this related data cannot be set.

