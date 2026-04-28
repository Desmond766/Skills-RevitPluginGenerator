---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewSlabEdge(Autodesk.Revit.DB.SlabEdgeType,Autodesk.Revit.DB.ReferenceArray)
zh: 文档、文件
source: html/fb368db2-914d-5867-0c4b-2380fbd3db49.htm
---
# Autodesk.Revit.Creation.Document.NewSlabEdge Method

**中文**: 文档、文件

Creates a slab edge along a reference array.

## Syntax (C#)
```csharp
public SlabEdge NewSlabEdge(
	SlabEdgeType SlabEdgeType,
	ReferenceArray references
)
```

## Parameters
- **SlabEdgeType** (`Autodesk.Revit.DB.SlabEdgeType`) - The type of the slab edge to create
- **references** (`Autodesk.Revit.DB.ReferenceArray`) - An array of planar lines and arcs that represents the place where you
want to place the slab edge.

## Returns
If successful a new slab edge object within the project, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the slab edge type does not exist in the given document.

