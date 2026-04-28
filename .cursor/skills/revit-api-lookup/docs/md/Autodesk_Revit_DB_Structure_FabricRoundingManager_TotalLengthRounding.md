---
kind: property
id: P:Autodesk.Revit.DB.Structure.FabricRoundingManager.TotalLengthRounding
source: html/0f6f6d3f-3563-34e5-ee5b-8c8293df0aa0.htm
---
# Autodesk.Revit.DB.Structure.FabricRoundingManager.TotalLengthRounding Property

The rounding for Cut Overall Length and Cut Overall Width parameters.

## Syntax (C#)
```csharp
public double TotalLengthRounding { get; set; }
```

## Remarks
IsActiveOnElement property has to be true. TotalLengthRounding is meaningless if IsActiveOnElement is false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given value for value is not a number
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The rounding value is not a positive value.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: IsActiveOnElement property is false.

