---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilder.SetFaceMaterialId(Autodesk.Revit.DB.BRepBuilderGeometryId,Autodesk.Revit.DB.ElementId)
source: html/8b7c7bed-57ef-a1e0-0fe2-529fe742e64a.htm
---
# Autodesk.Revit.DB.BRepBuilder.SetFaceMaterialId Method

Sets material id to a face.

## Syntax (C#)
```csharp
public void SetFaceMaterialId(
	BRepBuilderGeometryId faceId,
	ElementId materialId
)
```

## Parameters
- **faceId** (`Autodesk.Revit.DB.BRepBuilderGeometryId`) - Id of the face to which material id will be added. faceId was returned by a call to AddFace().
- **materialId** (`Autodesk.Revit.DB.ElementId`) - The material id associated with the face, or invalidElementId if none.
 It is not verified that materialId corresponds to a valid Material element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The supplied face id doesn't correspond to a face stored in this BRepBuilder object.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This BRepBuilder object isn't accepting new data, either because it has already been used to build geometry, or because of an error.
 Consult the State property of the BRepBuilder object for more details.

