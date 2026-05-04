---
kind: method
id: M:Autodesk.Revit.DB.View3D.SetOrientation(Autodesk.Revit.DB.ViewOrientation3D)
zh: 三维视图、3d视图
source: html/ee7fc871-6d9b-469d-9cef-702c801d6f5c.htm
---
# Autodesk.Revit.DB.View3D.SetOrientation Method

**中文**: 三维视图、3d视图

Sets the temporary orientation of the View3D. The new orientation is not saved in the document.

## Syntax (C#)
```csharp
public void SetOrientation(
	ViewOrientation3D newViewOrientation3D
)
```

## Parameters
- **newViewOrientation3D** (`Autodesk.Revit.DB.ViewOrientation3D`) - The new orientation to set.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - View is locked and cannot be reoriented.

