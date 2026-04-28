---
kind: method
id: M:Autodesk.Revit.DB.View.SetSketchyLines(Autodesk.Revit.DB.ViewDisplaySketchyLines)
zh: 视图
source: html/9cdaee30-673e-4adf-8fe0-38d3ecdbecd3.htm
---
# Autodesk.Revit.DB.View.SetSketchyLines Method

**中文**: 视图

Sets the sketchy lines settings for the view.

## Syntax (C#)
```csharp
public void SetSketchyLines(
	ViewDisplaySketchyLines sketchyLines
)
```

## Parameters
- **sketchyLines** (`Autodesk.Revit.DB.ViewDisplaySketchyLines`) - Sketchy Lines settings to set.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This view does not contain display-related properties.

