---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewSlabEdge(Autodesk.Revit.DB.SlabEdgeType,Autodesk.Revit.DB.Reference)
zh: 文档、文件
source: html/dbd42278-f7b8-03e3-b8b9-add9eb65022f.htm
---
# Autodesk.Revit.Creation.Document.NewSlabEdge Method

**中文**: 文档、文件

Creates a slab edge along a reference.

## Syntax (C#)
```csharp
public SlabEdge NewSlabEdge(
	SlabEdgeType SlabEdgeType,
	Reference reference
)
```

## Parameters
- **SlabEdgeType** (`Autodesk.Revit.DB.SlabEdgeType`) - The type of the slab edge to create
- **reference** (`Autodesk.Revit.DB.Reference`) - A planar line or arc that represents the place where you
want to place the slab edge.

## Returns
If successful a new slab edge object within the project, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the slab edge type does not exist in the given document.

