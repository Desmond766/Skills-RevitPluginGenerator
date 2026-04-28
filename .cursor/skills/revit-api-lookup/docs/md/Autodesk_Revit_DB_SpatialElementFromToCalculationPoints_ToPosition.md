---
kind: property
id: P:Autodesk.Revit.DB.SpatialElementFromToCalculationPoints.ToPosition
source: html/128045fd-8cd1-b9e2-2add-28f92a250876.htm
---
# Autodesk.Revit.DB.SpatialElementFromToCalculationPoints.ToPosition Property

The "to" position of spatial element connecting calculation point.

## Syntax (C#)
```csharp
public XYZ ToPosition { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: toPosition must be on the opposite side of the family's host from the "from" position.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

