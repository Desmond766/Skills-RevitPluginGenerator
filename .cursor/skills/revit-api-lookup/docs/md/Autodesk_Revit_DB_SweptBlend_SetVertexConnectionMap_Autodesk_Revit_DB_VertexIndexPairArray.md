---
kind: method
id: M:Autodesk.Revit.DB.SweptBlend.SetVertexConnectionMap(Autodesk.Revit.DB.VertexIndexPairArray)
source: html/0568a411-9c58-4c3e-83e3-57b7d60fe6f3.htm
---
# Autodesk.Revit.DB.SweptBlend.SetVertexConnectionMap Method

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

