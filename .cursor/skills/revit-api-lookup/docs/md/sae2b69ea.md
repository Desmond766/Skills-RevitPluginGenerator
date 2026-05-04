---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarRoundingManager.TotalLengthRounding
source: html/be6b3f74-8c2d-f1f6-0e37-978a493bb98b.htm
---
# Autodesk.Revit.DB.Structure.RebarRoundingManager.TotalLengthRounding Property

The rounding for Bar Length and Total Bar Length parameters.

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

