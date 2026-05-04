---
kind: method
id: M:Autodesk.Revit.UI.UIApplication.GetDockablePane(Autodesk.Revit.UI.DockablePaneId)
source: html/45a7e7c9-1bd2-b7aa-27c9-4efad9882870.htm
---
# Autodesk.Revit.UI.UIApplication.GetDockablePane Method

Gets a DockablePane object by its ID.

## Syntax (C#)
```csharp
public DockablePane GetDockablePane(
	DockablePaneId id
)
```

## Parameters
- **id** (`Autodesk.Revit.UI.DockablePaneId`) - Unique identifier for the new pane.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if no dockable pane has been registered with identifier %id%.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the dockable pane with identifier %id% has not been created yet.

