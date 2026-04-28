---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsRun.ExtensionBelowTreadBase
source: html/62bf2199-bce0-9eb6-62f3-5a5987586273.htm
---
# Autodesk.Revit.DB.Architecture.StairsRun.ExtensionBelowTreadBase Property

Specifies a value to extend/trim the run's first step against base elevation of the stairs if the stairs begins with a tread.

## Syntax (C#)
```csharp
public double ExtensionBelowTreadBase { get; set; }
```

## Remarks
This is useful in cases where the run attaches to the face of a floor opening rather than
 resting on the surface of the floor.
 Negative value extends the run's first step below the stairs' base elevation. Positive
 value trims it above the stairs' base elevation.
 This value should not be greater than run's top elevation.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for extendBelowTreadBase must be no more than 30000 feet in absolute value.
 -or-
 When setting this property: The extendBelowTreadBase is not less than run height.
 -or-
 When setting this property: The extendBelowTreadBase is greater than the top elevation of the stairs run.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The run cannot extend its below base because its base joins with other stairs components.
 -or-
 When setting this property: The run cannot extend its below tread base because it doesn't begin with a tread.

