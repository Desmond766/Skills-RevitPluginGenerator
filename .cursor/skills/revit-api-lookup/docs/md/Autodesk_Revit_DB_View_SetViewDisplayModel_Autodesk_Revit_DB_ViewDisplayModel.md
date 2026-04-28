---
kind: method
id: M:Autodesk.Revit.DB.View.SetViewDisplayModel(Autodesk.Revit.DB.ViewDisplayModel)
zh: 视图
source: html/93eb8a28-8807-9e9d-946c-5206f42efc1a.htm
---
# Autodesk.Revit.DB.View.SetViewDisplayModel Method

**中文**: 视图

Sets the view display model settings for the view.

## Syntax (C#)
```csharp
public void SetViewDisplayModel(
	ViewDisplayModel viewDisplayModel
)
```

## Parameters
- **viewDisplayModel** (`Autodesk.Revit.DB.ViewDisplayModel`) - View display model settings to set.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The silhouette line style id is not a valid line style to apply to the view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This view does not contain display-related properties.

