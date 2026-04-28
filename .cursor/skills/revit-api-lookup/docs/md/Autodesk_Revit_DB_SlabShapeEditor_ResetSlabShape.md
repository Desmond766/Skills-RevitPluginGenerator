---
kind: method
id: M:Autodesk.Revit.DB.SlabShapeEditor.ResetSlabShape
source: html/b94ace8b-5eb5-a25d-6a18-5e23d8905911.htm
---
# Autodesk.Revit.DB.SlabShapeEditor.ResetSlabShape Method

Removes the modifications made during editing and resets the element geometry back to the unmodified state.

## Syntax (C#)
```csharp
public void ResetSlabShape()
```

## Remarks
Calling this method will reset the slab back to its original state and disable Slab Shape Editing. If further
editing is needed, call Enable again.

