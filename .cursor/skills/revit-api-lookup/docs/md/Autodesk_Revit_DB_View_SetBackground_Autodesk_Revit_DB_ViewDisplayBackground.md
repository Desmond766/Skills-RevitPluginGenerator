---
kind: method
id: M:Autodesk.Revit.DB.View.SetBackground(Autodesk.Revit.DB.ViewDisplayBackground)
zh: 视图
source: html/7786585b-1165-983c-ffa8-a619cef1aa09.htm
---
# Autodesk.Revit.DB.View.SetBackground Method

**中文**: 视图

Sets the background for the view. Background can only be set for 3d views and for Sections/Elevations.

## Syntax (C#)
```csharp
public void SetBackground(
	ViewDisplayBackground background
)
```

## Parameters
- **background** (`Autodesk.Revit.DB.ViewDisplayBackground`) - Background to set. See 'ViewDisplayBackground' class and its 'create' methods.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The background object is invalid, or view has 'Rendering' style.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This view does not contain display-related properties.

