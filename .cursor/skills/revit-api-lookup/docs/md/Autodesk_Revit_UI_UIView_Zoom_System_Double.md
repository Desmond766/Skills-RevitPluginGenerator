---
kind: method
id: M:Autodesk.Revit.UI.UIView.Zoom(System.Double)
source: html/3087295d-ef9e-692c-9d4f-a4fdaad5f748.htm
---
# Autodesk.Revit.UI.UIView.Zoom Method

Zoom the view.

## Syntax (C#)
```csharp
public void Zoom(
	double zoomFactor
)
```

## Parameters
- **zoomFactor** (`System.Double`) - Factor by which to zoom in or out. Values greater than 1 zooms in, less than 1 zooms out.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - zoomFactor is not positive.

