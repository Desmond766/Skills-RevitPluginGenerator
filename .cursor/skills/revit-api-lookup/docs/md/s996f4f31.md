---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarRoundingManager.SegmentLengthRounding
source: html/e070853e-e1ba-b6ea-6713-88f914a1c681.htm
---
# Autodesk.Revit.DB.Structure.RebarRoundingManager.SegmentLengthRounding Property

The rounding for shared parameters used by rebar.

## Syntax (C#)
```csharp
public double SegmentLengthRounding { get; set; }
```

## Remarks
IsActiveOnElement property has to be true. SegmentLengthRounding is meaningless if IsActiveOnElement is false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given value for value is not a number
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The rounding value is not a positive value.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: IsActiveOnElement property is false.

