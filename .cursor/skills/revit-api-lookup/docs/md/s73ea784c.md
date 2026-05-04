---
kind: method
id: M:Autodesk.Revit.DB.View.SetDepthCueing(Autodesk.Revit.DB.ViewDisplayDepthCueing)
zh: 视图
source: html/1fce2f87-4d7d-e060-06c0-220c9d385763.htm
---
# Autodesk.Revit.DB.View.SetDepthCueing Method

**中文**: 视图

Sets the depth cueing settings for the view.

## Syntax (C#)
```csharp
public void SetDepthCueing(
	ViewDisplayDepthCueing depthCueing
)
```

## Parameters
- **depthCueing** (`Autodesk.Revit.DB.ViewDisplayDepthCueing`) - Depth cueing settings to set.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This view does not contain display-related properties.
 -or-
 This view cannot use Depth Cueing

