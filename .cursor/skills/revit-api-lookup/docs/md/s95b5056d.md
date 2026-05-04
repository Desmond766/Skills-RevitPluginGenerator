---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsType.LeftLateralOffset
source: html/dfc55b30-16bb-91f6-ad31-cc216b23dba3.htm
---
# Autodesk.Revit.DB.Architecture.StairsType.LeftLateralOffset Property

The offset for the left support from the edge of the run in a horizontal direction.

## Syntax (C#)
```csharp
public double LeftLateralOffset { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for offset must be between 0 and 30000 feet.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The left support style is not carriage(open), so this related data cannot be set.

