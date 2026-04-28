---
kind: method
id: M:Autodesk.Revit.DB.SlabShapeEditor.DeletePoint(Autodesk.Revit.DB.SlabShapeVertex)
source: html/4c1e94db-c98f-07e2-bd9b-8bb4feb1c66b.htm
---
# Autodesk.Revit.DB.SlabShapeEditor.DeletePoint Method

Delete a SlabShapeVertex from the element.

## Syntax (C#)
```csharp
public bool DeletePoint(
	SlabShapeVertex vertex
)
```

## Parameters
- **vertex** (`Autodesk.Revit.DB.SlabShapeVertex`) - The SlabShapeVertex to be deleted.

## Returns
True if the vertex is successfully deleted.
 False if the vertex is not found or could not be deleted.

## Remarks
Corner vertices are created right after the SlabShapeEditor is enabled.
 They are tied with the boundaries so that they could not be deleted individually.
 They can only be deleted using ResetSlabShape.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

