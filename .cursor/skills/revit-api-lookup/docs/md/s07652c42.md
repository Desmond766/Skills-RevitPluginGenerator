---
kind: method
id: M:Autodesk.Revit.DB.Solid.GetBoundingBox
source: html/716fecd9-7d09-fa61-5c02-de714259a214.htm
---
# Autodesk.Revit.DB.Solid.GetBoundingBox Method

Retrieves a box that circumscribes the solid geometry.

## Syntax (C#)
```csharp
public BoundingBoxXYZ GetBoundingBox()
```

## Remarks
The bounding box information is stored as bounds in local coordinates and a transform.
 So the transform is to be taken in to account when using the bounds.
 This is different from the bounding box returned by Element.BoundingBox in that the bounding box
 returned by that routine stores the bounds in modeling coordinates with an identity transform.

