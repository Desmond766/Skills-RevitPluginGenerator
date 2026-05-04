---
kind: method
id: M:Autodesk.Revit.UI.UIControlledApplication.GetDockablePane(Autodesk.Revit.UI.DockablePaneId)
source: html/71b907a8-c147-3c2e-b2e0-dc268c461e71.htm
---
# Autodesk.Revit.UI.UIControlledApplication.GetDockablePane Method

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

