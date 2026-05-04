---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.IDirectContext3DServer.GetBoundingBox(Autodesk.Revit.DB.View)
source: html/69b85527-f1e3-fee9-3431-4b8e0000963e.htm
---
# Autodesk.Revit.DB.DirectContext3D.IDirectContext3DServer.GetBoundingBox Method

Reports a bounding box of the geometry that this server submits for drawing.

## Syntax (C#)
```csharp
Outline GetBoundingBox(
	View dBView
)
```

## Parameters
- **dBView** (`Autodesk.Revit.DB.View`) - The view where rendering will occur. If this argument is Nothing nullptr a null reference ( Nothing in Visual Basic) , a view-independent bounding box should be reported.

## Returns
The bounding box as an Outline.

## Remarks
Revit uses the bounding box when navigating views, e.g., when a Zoom to Fit command is issued.
 The reported bounding box does not have to be tight. However, there may be unintended side-effects
 if the box is inconsistent with the submitted geometry.

