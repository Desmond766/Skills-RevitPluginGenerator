---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsLanding.BaseElevation
source: html/43d0fed8-4a1f-2cd3-0c01-33b13fec59c5.htm
---
# Autodesk.Revit.DB.Architecture.StairsLanding.BaseElevation Property

The base elevation of the landing.

## Syntax (C#)
```csharp
public double BaseElevation { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for height must be no more than 30000 feet in absolute value.
 -or-
 When setting this property: The height is less than half of the riser height of the stairs.

