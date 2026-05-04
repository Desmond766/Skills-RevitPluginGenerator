---
kind: method
id: M:Autodesk.Revit.DB.ImageInstance.IsValidView(Autodesk.Revit.DB.View)
source: html/ee7cd29b-d142-27e8-4fc0-4eff2109b1c1.htm
---
# Autodesk.Revit.DB.ImageInstance.IsValidView Method

Check that the view is a valid view for ImageInstance elements

## Syntax (C#)
```csharp
public static bool IsValidView(
	View view
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view to validate

## Returns
True if the view can contain ImageInstance elements. False otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

