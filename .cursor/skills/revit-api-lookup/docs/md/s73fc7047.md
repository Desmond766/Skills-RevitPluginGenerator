---
kind: method
id: M:Autodesk.Revit.DB.View3D.SetSectionBox(Autodesk.Revit.DB.BoundingBoxXYZ)
zh: 三维视图、3d视图
source: html/e21471cd-63a4-c452-8c29-fad41362a59b.htm
---
# Autodesk.Revit.DB.View3D.SetSectionBox Method

**中文**: 三维视图、3d视图

Sets the section box for this 3D view.

## Syntax (C#)
```csharp
public void SetSectionBox(
	BoundingBoxXYZ boundingBoxXYZ
)
```

## Parameters
- **boundingBoxXYZ** (`Autodesk.Revit.DB.BoundingBoxXYZ`) - The bounding box to use for the section box. To turn off the section box, set IsSectionBoxActive to false.
 Individual bound enabled flags in the input box are ignored.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Bounding box cannot be empty.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Returns true if the view is not a view template.

