---
kind: property
id: P:Autodesk.Revit.DB.Structure.FabricRoundingManager.SegmentLengthRounding
source: html/204bff41-9ab8-9d1b-f1ff-b84390f43f51.htm
---
# Autodesk.Revit.DB.Structure.FabricRoundingManager.SegmentLengthRounding Property

The rounding for fabric segments.

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

