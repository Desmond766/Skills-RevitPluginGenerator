---
kind: method
id: M:Autodesk.Revit.DB.ReferencePoint.SetCoordinateSystem(Autodesk.Revit.DB.Transform)
source: html/1531d27f-9b12-57d7-533e-eda4daf99adb.htm
---
# Autodesk.Revit.DB.ReferencePoint.SetCoordinateSystem Method

The position and orientation of the ReferencePoint.

## Syntax (C#)
```csharp
public void SetCoordinateSystem(
	Transform coordinateSystem
)
```

## Parameters
- **coordinateSystem** (`Autodesk.Revit.DB.Transform`)

## Remarks
The position of the point is given by
CoordinateSystem.Origin, and the orientation is specified
by the three unit vectors CoordinateSystem.BasisX, BasisY,
BasisZ. The basis vectors must be unit length and mutually
perpendicular.
Whenever the Reference property is not Nothing nullptr a null reference ( Nothing in Visual Basic) ,
changing the CoordinateSystem property has a compound
effect. First the point is moved to the specified
location. Then the point is moved to conform to its
Reference, by the shortest possible distance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when coordinateSystem does not specify an 
orthonormal basis.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when CoordinateSystem is set while the Reference 
property is not Nothing nullptr a null reference ( Nothing in Visual Basic) , and the ReferencePoint is unable to
move to the new location.

