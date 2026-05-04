---
kind: method
id: M:Autodesk.Revit.DB.SpatialElementBoundarySubface.GetSubface
source: html/c53f2132-bc08-1650-b1c6-bc7b66ff7a5d.htm
---
# Autodesk.Revit.DB.SpatialElementBoundarySubface.GetSubface Method

Returns a face that represents the portion of the room face bounded by the boundary element.

## Syntax (C#)
```csharp
public Face GetSubface()
```

## Returns
The sub-face.

## Remarks
If the spatial element's face is adjacent to multiple bounding elements (such as two different walls), there will be one sub-face
 for each portion of the spatial element's face where it is adjacent to one of those room-bounding elements.
 This is equivalent to the return of GetRoomFace() if the entire room face is created by the boundary element.

