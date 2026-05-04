---
kind: method
id: M:Autodesk.Revit.DB.FaceWall.IsValidFaceReferenceForFaceWall(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Reference)
source: html/82a3b2c5-c712-b558-2b4f-825c2e841611.htm
---
# Autodesk.Revit.DB.FaceWall.IsValidFaceReferenceForFaceWall Method

Identifies if a reference may be used as the parent of a face wall.

## Syntax (C#)
```csharp
public static bool IsValidFaceReferenceForFaceWall(
	Document document,
	Reference faceReference
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **faceReference** (`Autodesk.Revit.DB.Reference`) - The reference.

## Returns
True if the reference is valid as a parent to a face wall, false otherwise.

## Remarks
The reference must represent a face of a massing instance, and
 must be planar, and its normal must not be vertical or horizontal.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

