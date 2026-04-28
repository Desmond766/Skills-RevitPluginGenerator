---
kind: method
id: M:Autodesk.Revit.Creation.Application.NewPointOnEdgeEdgeIntersection(Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.Reference)
source: html/efab2f45-02ef-468c-2921-63441c614bf0.htm
---
# Autodesk.Revit.Creation.Application.NewPointOnEdgeEdgeIntersection Method

Construct a PointOnEdgeEdgeIntersection object which is used to define the placement of a ReferencePoint given two references to edge.

## Syntax (C#)
```csharp
public PointOnEdgeEdgeIntersection NewPointOnEdgeEdgeIntersection(
	Reference edgeReference1,
	Reference edgeReference2
)
```

## Parameters
- **edgeReference1** (`Autodesk.Revit.DB.Reference`) - The first edge reference.
- **edgeReference2** (`Autodesk.Revit.DB.Reference`) - The second edge reference.

## Returns
A new PointOnEdgeEdgeIntersection object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument edgeReference1 or edgeReference2 is Nothing nullptr a null reference ( Nothing in Visual Basic) .

