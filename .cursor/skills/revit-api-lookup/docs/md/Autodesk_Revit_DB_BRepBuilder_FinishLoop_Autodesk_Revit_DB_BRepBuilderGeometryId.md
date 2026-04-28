---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilder.FinishLoop(Autodesk.Revit.DB.BRepBuilderGeometryId)
source: html/cf38cd16-7b71-62d3-8c4f-56694125a4be.htm
---
# Autodesk.Revit.DB.BRepBuilder.FinishLoop Method

Indicates that the caller has finished defining the given loop.

## Syntax (C#)
```csharp
public void FinishLoop(
	BRepBuilderGeometryId loopId
)
```

## Parameters
- **loopId** (`Autodesk.Revit.DB.BRepBuilderGeometryId`) - Id of the loop.

## Remarks
No functions that modify the given loop's definition should be called after calling this function (e.g., AddCoEdge(BRepBuilderGeometryId, BRepBuilderGeometryId, Boolean) ).
 The BRepBuilder may take the opportunity to validate some of the loop's data and report any problems it finds.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The supplied loop id doesn't correspond to a loop stored in this BRepBuilder object.
 -or-
 FinishLoop() has already been called on loopId.
 -or-
 The edge loop has fewer than two co-edges.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

