---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilder.FinishFace(Autodesk.Revit.DB.BRepBuilderGeometryId)
source: html/2d5b2123-3d60-f87c-2f5f-b61fd2db62ce.htm
---
# Autodesk.Revit.DB.BRepBuilder.FinishFace Method

Indicates that the caller has finished defining the given face.

## Syntax (C#)
```csharp
public void FinishFace(
	BRepBuilderGeometryId faceId
)
```

## Parameters
- **faceId** (`Autodesk.Revit.DB.BRepBuilderGeometryId`) - Id of the face.

## Remarks
No functions that modify the given face's definition should be called after calling this function (e.g., AddLoop(BRepBuilderGeometryId) , SetFaceMaterialId(BRepBuilderGeometryId, ElementId) ).
 The BRepBuilder may take the opportunity to validate some of the face's data and report any problems it finds.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The supplied face id doesn't correspond to a face stored in this BRepBuilder object.
 -or-
 FinishFace() has already been called on faceId.
 -or-
 The face has no edge loops.
 -or-
 FinishLoop() must be called on all the edge loops of faceId.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

