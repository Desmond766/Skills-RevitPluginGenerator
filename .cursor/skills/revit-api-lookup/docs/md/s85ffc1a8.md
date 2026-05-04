---
kind: method
id: M:Autodesk.Revit.Creation.Application.NewPointOnEdgeFaceIntersection(Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.Reference,System.Boolean)
source: html/2808db12-64d0-0878-75b8-747405efe505.htm
---
# Autodesk.Revit.Creation.Application.NewPointOnEdgeFaceIntersection Method

Construct a PointOnEdgeFaceIntersection object which is used to define the placement of a ReferencePoint given a references to edge and a reference to face.

## Syntax (C#)
```csharp
public PointOnEdgeFaceIntersection NewPointOnEdgeFaceIntersection(
	Reference edgeReference,
	Reference faceReference,
	bool orientWithEdge
)
```

## Parameters
- **edgeReference** (`Autodesk.Revit.DB.Reference`) - The edge reference.
- **faceReference** (`Autodesk.Revit.DB.Reference`) - The face reference.
- **orientWithEdge** (`System.Boolean`)

## Returns
A new PointOnEdgeFaceIntersection object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument edgeReference or faceReference is Nothing nullptr a null reference ( Nothing in Visual Basic) .

