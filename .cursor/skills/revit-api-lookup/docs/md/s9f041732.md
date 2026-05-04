---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilder.AddLoop(Autodesk.Revit.DB.BRepBuilderGeometryId)
source: html/169a75b9-2b82-09ec-a6f1-a9b82e8f32fe.htm
---
# Autodesk.Revit.DB.BRepBuilder.AddLoop Method

Creates an empty loop in a given face of the geometry being built. Other BRepBuilder methods are used to add co-edges to the loop.

## Syntax (C#)
```csharp
public BRepBuilderGeometryId AddLoop(
	BRepBuilderGeometryId faceId
)
```

## Parameters
- **faceId** (`Autodesk.Revit.DB.BRepBuilderGeometryId`) - Id of the face to which the loop should be added. faceId was returned by a call to AddFace().

## Returns
An id that can be used to identify the loop while the BRepBuilder is actively building geometry (e.g., to add co-edges to the loop).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The supplied face id doesn't correspond to a face stored in this BRepBuilder object.
 -or-
 FinishFace() has already been called on faceId.
 -or-
 Please finish the previous loop by calling FinishLoop() before adding a new one.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This BRepBuilder object isn't accepting new data, either because it has already been used to build geometry, or because of an error.
 Consult the State property of the BRepBuilder object for more details.

