---
kind: method
id: M:Autodesk.Revit.Creation.Application.NewPointOnFace(Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.UV)
source: html/6ed552c6-7179-6a4e-3f97-294e37eb9a58.htm
---
# Autodesk.Revit.Creation.Application.NewPointOnFace Method

Construct a PointOnFace object which is used to define the placement of a ReferencePoint given a reference and a location on the face.

## Syntax (C#)
```csharp
public PointOnFace NewPointOnFace(
	Reference faceReference,
	UV uv
)
```

## Parameters
- **faceReference** (`Autodesk.Revit.DB.Reference`) - The reference whose face the object will be created on.
- **uv** (`Autodesk.Revit.DB.UV`) - A 2-dimensional position.

## Returns
A new PointOnFace object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument faceReference or uv is Nothing nullptr a null reference ( Nothing in Visual Basic) .

