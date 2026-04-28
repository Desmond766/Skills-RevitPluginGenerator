---
kind: method
id: M:Autodesk.Revit.DB.TessellatedShapeBuilder.DoesFaceHaveEnoughLoopsAndVertices(Autodesk.Revit.DB.TessellatedFace)
source: html/894594d4-e75a-843e-ed5f-c9554feec2f4.htm
---
# Autodesk.Revit.DB.TessellatedShapeBuilder.DoesFaceHaveEnoughLoopsAndVertices Method

Checks whether 'face' has enough loops and vertcies to be valid.

## Syntax (C#)
```csharp
public bool DoesFaceHaveEnoughLoopsAndVertices(
	TessellatedFace face
)
```

## Parameters
- **face** (`Autodesk.Revit.DB.TessellatedFace`) - The face to check.

## Remarks
Face 'face' is not modified.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

