---
kind: method
id: M:Autodesk.Revit.DB.Blend.SetVertexConnectionMap(Autodesk.Revit.DB.VertexIndexPairArray)
source: html/9d580df7-a1e7-55cb-48a5-06f2db1538ae.htm
---
# Autodesk.Revit.DB.Blend.SetVertexConnectionMap Method

Sets the mapping between the vertices in the top and bottom profiles.

## Syntax (C#)
```csharp
public void SetVertexConnectionMap(
	VertexIndexPairArray vertexMap
)
```

## Parameters
- **vertexMap** (`Autodesk.Revit.DB.VertexIndexPairArray`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"vertexMap"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the input argument-"vertexMap"-is empty.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the document failed to regenerate.

