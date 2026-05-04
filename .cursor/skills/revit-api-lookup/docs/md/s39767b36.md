---
kind: method
id: M:Autodesk.Revit.DB.View3D.GetSectionBox
zh: 三维视图、3d视图
source: html/1563dc0f-db89-526d-340b-cdee72e3d254.htm
---
# Autodesk.Revit.DB.View3D.GetSectionBox Method

**中文**: 三维视图、3d视图

Gets a copy of the section box for this 3D view.

## Syntax (C#)
```csharp
public BoundingBoxXYZ GetSectionBox()
```

## Returns
The section box. Note that the section box can be rotated and transformed and thus you will need to use
 [!:Autodesk::Revit::DB::BoundingBoxXYZ::Transform] to
 interpret the coordinates of the corners or sides of the box in model coordinates.

## Remarks
The section box cuts the model in this view by its boundaries.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Returns true if the view is not a view template.

