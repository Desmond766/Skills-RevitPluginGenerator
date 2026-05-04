---
kind: method
id: M:Autodesk.Revit.Creation.Application.NewPointOnPlane(Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.UV,Autodesk.Revit.DB.UV,System.Double)
source: html/d5cdc451-58fc-2207-43bb-92f3a90db638.htm
---
# Autodesk.Revit.Creation.Application.NewPointOnPlane Method

Construct a PointOnPlane object which is used to define the placement of a ReferencePoint from its property values.

## Syntax (C#)
```csharp
public PointOnPlane NewPointOnPlane(
	Reference planeReference,
	UV position,
	UV xvec,
	double offset
)
```

## Parameters
- **planeReference** (`Autodesk.Revit.DB.Reference`) - A reference to some plane
in the document. (Note: the reference must satisfy
IsValidPlaneReference(), 
but this is not checked until this PointOnPlane object
is assigned to a ReferencePoint.)
- **position** (`Autodesk.Revit.DB.UV`) - Coordinates of the point's projection onto the plane;
see the Position property.
- **xvec** (`Autodesk.Revit.DB.UV`) - The direction of the point's
X-coordinate vector in the plane's coordinates; see the XVec property. Optional;
default value is (1, 0).
- **offset** (`System.Double`) - Signed offset from the plane; see the Offset property.

## Returns
A new PointOnPlane object with 2-dimensional Position, XVec, and Offset
properties set to match the given 3-dimensional arguments.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument planeReference or position or xvec is Nothing nullptr a null reference ( Nothing in Visual Basic) or offset is not a valid double value.

