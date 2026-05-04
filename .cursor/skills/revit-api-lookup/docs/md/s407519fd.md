---
kind: method
id: M:Autodesk.Revit.DB.SpatialElementBoundarySubface.GetBoundingElementFace
source: html/3a2c1bf4-a48a-371c-e6d5-0c4cdcfd14b3.htm
---
# Autodesk.Revit.DB.SpatialElementBoundarySubface.GetBoundingElementFace Method

Returns the face of the bounding element.

## Syntax (C#)
```csharp
public Face GetBoundingElementFace()
```

## Returns
The face of the bounding element.

## Remarks
Applies only if the options chosen for the extraction of the element's geometry is Finish.
 Faces do not contain voids in room-bounding elements (such the voids in walls created by doors and windows).

