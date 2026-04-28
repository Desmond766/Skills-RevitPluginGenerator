---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilder.IsValidPersistentIdsMap(Autodesk.Revit.DB.BRepBuilderPersistentIds)
source: html/4169de01-5062-fd9c-024f-c7958fc85402.htm
---
# Autodesk.Revit.DB.BRepBuilder.IsValidPersistentIdsMap Method

A validator function that makes sure that all BRepBuilderGeometryIds in the input map can be found in this BRepBuilder object.

## Syntax (C#)
```csharp
public bool IsValidPersistentIdsMap(
	BRepBuilderPersistentIds brepPersistentIds
)
```

## Parameters
- **brepPersistentIds** (`Autodesk.Revit.DB.BRepBuilderPersistentIds`) - The map that associates ExternalGeometryIds to BRepBuilderGeometryIds.

## Returns
True if all BRepBuilderGeometryIds in the input map can be found in this BRepBuilder object, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

