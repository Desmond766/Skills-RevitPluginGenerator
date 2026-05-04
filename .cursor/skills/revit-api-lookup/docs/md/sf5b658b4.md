---
kind: method
id: M:Autodesk.Revit.DB.PointOnPlane.SetPlaneReference(Autodesk.Revit.DB.Reference)
source: html/44adcf08-cbba-6338-5c4f-d70cc78b447a.htm
---
# Autodesk.Revit.DB.PointOnPlane.SetPlaneReference Method

Change the geometric plane reference.

## Syntax (C#)
```csharp
public void SetPlaneReference(
	Reference planeReference
)
```

## Parameters
- **planeReference** (`Autodesk.Revit.DB.Reference`) - A reference to some plane
in the document. (Note: the reference must satisfy
IsValidPlaneReference(), 
but this is not checked until this PointOnPlane object
is assigned to a ReferencePoint.)

