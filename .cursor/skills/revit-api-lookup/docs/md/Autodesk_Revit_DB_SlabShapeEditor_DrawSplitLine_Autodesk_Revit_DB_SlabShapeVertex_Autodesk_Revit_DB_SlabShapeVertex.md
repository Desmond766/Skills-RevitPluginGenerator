---
kind: method
id: M:Autodesk.Revit.DB.SlabShapeEditor.DrawSplitLine(Autodesk.Revit.DB.SlabShapeVertex,Autodesk.Revit.DB.SlabShapeVertex)
source: html/fb041590-6361-7fda-4f48-6e381dbb9f5d.htm
---
# Autodesk.Revit.DB.SlabShapeEditor.DrawSplitLine Method

Draws a split line on the corresponding slab, roof or floor.

## Syntax (C#)
```csharp
public SlabShapeCreaseArray DrawSplitLine(
	SlabShapeVertex startVertex,
	SlabShapeVertex endVertex
)
```

## Parameters
- **startVertex** (`Autodesk.Revit.DB.SlabShapeVertex`) - The vertex to start the split line.
- **endVertex** (`Autodesk.Revit.DB.SlabShapeVertex`) - The vertex to end the split line.

## Returns
The newly created creases.

## Remarks
Drawing a split line may result in multiple creases, for example when the line crosses existing creases or boundary edges.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input vertex is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input vertex is invalid.

