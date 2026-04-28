---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.GetVertex(System.Int32)
source: html/0839473c-cba3-e749-e940-213dcabf3e09.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.GetVertex Method

Return a reference to one of the vertices in the definition.

## Syntax (C#)
```csharp
public RebarShapeVertex GetVertex(
	int vertexIndex
)
```

## Parameters
- **vertexIndex** (`System.Int32`) - Index of the vertex (0 to NumberOfVertices - 1).

## Returns
The requested vertex.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - vertexIndex is not between 0 and NumberOfVertices.

