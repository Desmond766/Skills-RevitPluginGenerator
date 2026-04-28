---
kind: method
id: M:Autodesk.Revit.UI.UIDocument.ShowElements(Autodesk.Revit.DB.ElementId)
source: html/4a60dd3d-3c60-9298-2252-b5e263c35e4c.htm
---
# Autodesk.Revit.UI.UIDocument.ShowElements Method

Shows the element by zoom to fit.

## Syntax (C#)
```csharp
public void ShowElements(
	ElementId elementId
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - Element id that will be shown.

## Remarks
Places the element in the center of screen by moving the view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Element id is not valid.

