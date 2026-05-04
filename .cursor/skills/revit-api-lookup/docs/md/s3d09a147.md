---
kind: method
id: M:Autodesk.Revit.DB.TessellatedShapeBuilder.AddFace(Autodesk.Revit.DB.TessellatedFace)
source: html/401c4066-4ec1-be8c-53ae-daea44f3244d.htm
---
# Autodesk.Revit.DB.TessellatedShapeBuilder.AddFace Method

Adds a face to the currently open connected face set.

## Syntax (C#)
```csharp
public void AddFace(
	TessellatedFace face
)
```

## Parameters
- **face** (`Autodesk.Revit.DB.TessellatedFace`) - Face to add. The 'face' parameter can be added only once, as its
 boundary loops will be cleared while adding and 'face' will become unusable.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The 'face' does not have enough loops and/or vertices to be valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - A face set is closed and faces cannot be added to it.

