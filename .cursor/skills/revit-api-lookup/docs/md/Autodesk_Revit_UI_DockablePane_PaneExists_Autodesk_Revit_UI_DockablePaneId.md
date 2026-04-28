---
kind: method
id: M:Autodesk.Revit.UI.DockablePane.PaneExists(Autodesk.Revit.UI.DockablePaneId)
source: html/113303aa-57ec-67d2-a5aa-76a1ad7ebeea.htm
---
# Autodesk.Revit.UI.DockablePane.PaneExists Method

Returns true if %id% refers to a dockable pane window that currently exists in the Revit user interface, whether it's hidden or shown.

## Syntax (C#)
```csharp
public static bool PaneExists(
	DockablePaneId id
)
```

## Parameters
- **id** (`Autodesk.Revit.UI.DockablePaneId`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

