---
kind: property
id: P:Autodesk.Revit.DB.Structure.PathReinforcement.PrimaryBarShapeId
source: html/06e0653f-9e58-c180-67b3-cbdd74f2d345.htm
---
# Autodesk.Revit.DB.Structure.PathReinforcement.PrimaryBarShapeId Property

The RebarShape element that defines the shape of the primary bars of the Path Reinforcement.

## Syntax (C#)
```csharp
public ElementId PrimaryBarShapeId { get; set; }
```

## Remarks
Changing the value of this property causes the Path Reinforcement to choose values for its
 shape parameters.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: shapeId should refer to two dimensional Rebar Shape element with segments forming only right angles.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: This PathReinforcement does not host Rebar.

