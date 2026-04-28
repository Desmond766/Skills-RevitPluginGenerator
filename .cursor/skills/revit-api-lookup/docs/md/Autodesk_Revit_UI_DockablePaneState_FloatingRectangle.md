---
kind: property
id: P:Autodesk.Revit.UI.DockablePaneState.FloatingRectangle
source: html/d1dcb64c-2f08-d2a6-ddc7-01c76c1a6a59.htm
---
# Autodesk.Revit.UI.DockablePaneState.FloatingRectangle Property

When %dockPosition% is Floating, this rectangle determines the size and position of the pane. Coordinates are relative to the upper-left-hand corner of the main Revit window.
 Note: the returned Rectangle is a copy. In order to change the pane state, you must call SetFloatingRectangle with a modified rectangle.

## Syntax (C#)
```csharp
public Rectangle FloatingRectangle { get; }
```

