---
kind: property
id: P:Autodesk.Revit.DB.Structure.PathReinforcement.AlternatingBarShapeId
source: html/192a6b79-2b79-b4f3-a084-8dd0940d9e42.htm
---
# Autodesk.Revit.DB.Structure.PathReinforcement.AlternatingBarShapeId Property

The RebarShape element that defines the shape of the alternating bars of the Path Reinforcement.

## Syntax (C#)
```csharp
public ElementId AlternatingBarShapeId { get; set; }
```

## Remarks
Changing the value of this property causes the Path Reinforcement to choose values for its
 shape parameters.
 Before calling this method, alternating bars have to be enabled in the Path Reinforcement by setting PATH_REIN_ALTERNATING BuiltInParameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: shapeId should refer to two dimensional Rebar Shape element with segments forming only right angles.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: This Path Reinforcement does not have alternating bars enabled.
 -or-
 When setting this property: This PathReinforcement does not host Rebar.

