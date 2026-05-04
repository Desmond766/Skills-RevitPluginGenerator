---
kind: method
id: M:Autodesk.Revit.DB.Part.SetFaceOffset(Autodesk.Revit.DB.Face,System.Double)
source: html/6d2cb1e0-1754-8f71-f02f-70c153fe6bde.htm
---
# Autodesk.Revit.DB.Part.SetFaceOffset Method

Offsets the given part face in the direction that points out of the solid shape with the specified amount.
 Negative value will offset the face into the solid shape.

## Syntax (C#)
```csharp
public void SetFaceOffset(
	Face face,
	double offset
)
```

## Parameters
- **face** (`Autodesk.Revit.DB.Face`) - The face to offset.
- **offset** (`System.Double`) - The magnitude of the offset.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - face does not belong to the part.
 -or-
 The face to be offset should be planar and satisfy constraints of its parent element
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

