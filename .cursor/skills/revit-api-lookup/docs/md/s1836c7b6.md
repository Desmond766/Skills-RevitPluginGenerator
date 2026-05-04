---
kind: method
id: M:Autodesk.Revit.DB.FreeFormElement.SetFaceOffset(Autodesk.Revit.DB.Face,System.Double)
source: html/74cb7799-030d-aa76-0009-f2ac59aee9a8.htm
---
# Autodesk.Revit.DB.FreeFormElement.SetFaceOffset Method

Offsets a planar face of the free form element a certain distance in the normal direction.

## Syntax (C#)
```csharp
public void SetFaceOffset(
	Face face,
	double offset
)
```

## Parameters
- **face** (`Autodesk.Revit.DB.Face`) - The face to offset.
- **offset** (`System.Double`) - The magnitude of the offset. A positive value offsets out of the input solid. A negative value offsets into the solid shape.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - face does not belong to the solid.
 -or-
 The face to be offset should be planar and satisfy constraints of its parent element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

