---
kind: method
id: M:Autodesk.Revit.Creation.Application.NewPointOnEdge(Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.PointLocationOnCurve)
source: html/57f52b30-8630-3ce0-c3ce-0ab3630992f6.htm
---
# Autodesk.Revit.Creation.Application.NewPointOnEdge Method

Create a PointOnEdge object which is used to define the placement of a ReferencePoint.

## Syntax (C#)
```csharp
public PointOnEdge NewPointOnEdge(
	Reference edgeReference,
	PointLocationOnCurve locationOnCurve
)
```

## Parameters
- **edgeReference** (`Autodesk.Revit.DB.Reference`) - The reference whose edge the object will be created on.
- **locationOnCurve** (`Autodesk.Revit.DB.PointLocationOnCurve`) - The location on the edge.

## Returns
If creation was successful then a new object is returned,
otherwise an exception with failure information will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument edgeReference or locationOnCurve is Nothing nullptr a null reference ( Nothing in Visual Basic) .

