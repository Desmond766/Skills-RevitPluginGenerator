---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilder.IsValidLoopId(Autodesk.Revit.DB.BRepBuilderGeometryId)
source: html/8688abac-8e16-f7f7-d6ad-e84d8620d503.htm
---
# Autodesk.Revit.DB.BRepBuilder.IsValidLoopId Method

A validator function that checks whether the loop id corresponds to a loop previously added to this BRepBuilder object.

## Syntax (C#)
```csharp
public bool IsValidLoopId(
	BRepBuilderGeometryId loopId
)
```

## Parameters
- **loopId** (`Autodesk.Revit.DB.BRepBuilderGeometryId`) - Loop id to be validated.

## Returns
True if loopId corresponds to a loop previously added to this BRepBuilder, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

