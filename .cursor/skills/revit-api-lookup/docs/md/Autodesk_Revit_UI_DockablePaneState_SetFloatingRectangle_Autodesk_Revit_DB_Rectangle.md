---
kind: method
id: M:Autodesk.Revit.UI.DockablePaneState.SetFloatingRectangle(Autodesk.Revit.DB.Rectangle)
source: html/0dda1168-e11a-a276-1535-74c64c677c4c.htm
---
# Autodesk.Revit.UI.DockablePaneState.SetFloatingRectangle Method

When %dockPosition% is Floating, sets the rectangle used to determine the size and position of the pane when %dockPosition% is Floating. Coordinates are relative to the upper-left-hand corner of the main Revit window.

## Syntax (C#)
```csharp
public void SetFloatingRectangle(
	Rectangle rect
)
```

## Parameters
- **rect** (`Autodesk.Revit.DB.Rectangle`) - The rectangle to use when floating.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Rectangle is not normalized.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

