---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilderPersistentIds.IsBRepBuilderGeometryIdFaceOrEdge(Autodesk.Revit.DB.BRepBuilderGeometryId)
source: html/22fae990-9618-4ea0-3fc7-775000c40a94.htm
---
# Autodesk.Revit.DB.BRepBuilderPersistentIds.IsBRepBuilderGeometryIdFaceOrEdge Method

Validates the input BRepBuilderGeometryId that will be used to create a correspondence.
 In order to be valid, the input BRepBuilderGeometryId must represent the ID of either a Face or an Edge.

## Syntax (C#)
```csharp
public bool IsBRepBuilderGeometryIdFaceOrEdge(
	BRepBuilderGeometryId brepBuilderGeometryId
)
```

## Parameters
- **brepBuilderGeometryId** (`Autodesk.Revit.DB.BRepBuilderGeometryId`) - The BRepBuilderGeometryId to be used in a new correspondence.

## Returns
True if the input BRepBuilderGeometryId represents the ID of either a Face or an Edge, false otherwise.

## Remarks
This method returns false also in the case when the associated BRepBuilder is not valid.
 Call IsAssociatedBRepBuilderValid () () () to check the associated BRepBuilder.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

