---
kind: property
id: P:Autodesk.Revit.DB.SpatialElementFromToCalculationPoints.FromPosition
source: html/45dfa54d-baaf-e72f-4216-21c2034fe4f0.htm
---
# Autodesk.Revit.DB.SpatialElementFromToCalculationPoints.FromPosition Property

The "from" position of spatial element connecting calculation point.

## Syntax (C#)
```csharp
public XYZ FromPosition { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: fromPosition must be on the opposite side of the family's host from the "to" position.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

