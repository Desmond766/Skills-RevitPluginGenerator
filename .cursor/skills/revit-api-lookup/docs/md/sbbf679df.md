---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilderPersistentIds.AddSubTag(Autodesk.Revit.DB.ExternalGeometryId,Autodesk.Revit.DB.BRepBuilderGeometryId)
source: html/c8bf3c16-6864-8323-3c57-c132e9282473.htm
---
# Autodesk.Revit.DB.BRepBuilderPersistentIds.AddSubTag Method

Adds a correspondence between an ExternalGeometryId and a BRepBuilderGeometryId.
 Note that an existing correspondence in the map cannot be updated and that a
 particular BRepBuilderGeometryId may be related to at most one ExternalGeometryId.

## Syntax (C#)
```csharp
public void AddSubTag(
	ExternalGeometryId externalGeometryId,
	BRepBuilderGeometryId brepBuilderGeometryId
)
```

## Parameters
- **externalGeometryId** (`Autodesk.Revit.DB.ExternalGeometryId`) - An external geometry object Id.
- **brepBuilderGeometryId** (`Autodesk.Revit.DB.BRepBuilderGeometryId`) - A BRepBuilder geometry object Id. It must represent the ID of either a Face or an Edge.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - externalGeometryId cannot be used to create a new correspondence because it is already used.
 -or-
 brepBuilderGeometryId cannot be used to create a new correspondence because it is already used.
 -or-
 brepBuilderGeometryId cannot be used to create a new correspondence because it doesn't represent the ID of either a Face or an Edge.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The associated BRepBuilder doesn't exist or is not valid (has no Faces and no Edges).

