---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilderPersistentIds.IsValidBRepBuilderGeometryIdForNewCorrespondence(Autodesk.Revit.DB.BRepBuilderGeometryId)
source: html/1d7e2823-e05b-2519-a55b-1b3075744497.htm
---
# Autodesk.Revit.DB.BRepBuilderPersistentIds.IsValidBRepBuilderGeometryIdForNewCorrespondence Method

Validates the input BRepBuilderGeometryId that will be used to create a correspondence.
 In order to be valid, a correspondence for the input BRepBuilderGeometryId must not already exist.

## Syntax (C#)
```csharp
public bool IsValidBRepBuilderGeometryIdForNewCorrespondence(
	BRepBuilderGeometryId brepBuilderGeometryId
)
```

## Parameters
- **brepBuilderGeometryId** (`Autodesk.Revit.DB.BRepBuilderGeometryId`) - The BRepBuilderGeometryId to be used in a new correspondence.

## Returns
True if the input BRepBuilderGeometryId can be used to create a new correspondence.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

