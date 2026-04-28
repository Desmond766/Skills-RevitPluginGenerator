---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsRun.ExtensionBelowRiserBase
source: html/31d69dbe-84d3-e559-20a0-f50d98c16820.htm
---
# Autodesk.Revit.DB.Architecture.StairsRun.ExtensionBelowRiserBase Property

Specifies a value to extend/trim the run's first step against base elevation of the stairs if the stairs begins with a riser.

## Syntax (C#)
```csharp
public double ExtensionBelowRiserBase { get; set; }
```

## Remarks
This is useful in cases where the run attaches to the face of a floor opening rather than
 resting on the surface of the floor.
 Negative value extends the run's first step below the stairs' base elevation. Positive
 value trims it above the stairs' base elevation.
 This value should not be greater than run's top elevation.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for extendBelowRiserBase must be no more than 30000 feet in absolute value.
 -or-
 When setting this property: The extendBelowRiserBase is not less than run height.
 -or-
 When setting this property: The extendBelowRiserBase is greater than the top elevation of the stairs run.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The run cannot extend its below base because its base joins with other stairs components.
 -or-
 When setting this property: The run cannot extend its below riser base because it doesn't begin with a riser.

