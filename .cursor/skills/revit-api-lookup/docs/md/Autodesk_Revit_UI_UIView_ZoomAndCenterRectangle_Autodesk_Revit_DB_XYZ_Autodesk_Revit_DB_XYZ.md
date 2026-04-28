---
kind: method
id: M:Autodesk.Revit.UI.UIView.ZoomAndCenterRectangle(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
source: html/d032146c-1fe9-82b8-74f1-0b62fb4fd097.htm
---
# Autodesk.Revit.UI.UIView.ZoomAndCenterRectangle Method

Zoom and center the view to a specified rectangle.

## Syntax (C#)
```csharp
public void ZoomAndCenterRectangle(
	XYZ viewCorner1,
	XYZ viewCorner2
)
```

## Parameters
- **viewCorner1** (`Autodesk.Revit.DB.XYZ`) - A corner of the desired view rectangle in model coordinates.
- **viewCorner2** (`Autodesk.Revit.DB.XYZ`) - The opposite corner of the desired view rectangle in model coordinates.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

