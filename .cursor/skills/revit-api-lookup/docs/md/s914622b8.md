---
kind: method
id: M:Autodesk.Revit.UI.UIApplication.RegisterDockablePane(Autodesk.Revit.UI.DockablePaneId,System.String,Autodesk.Revit.UI.IDockablePaneProvider)
source: html/8b0d1acb-838a-d11e-aa38-7d8207be8d32.htm
---
# Autodesk.Revit.UI.UIApplication.RegisterDockablePane Method

Adds a new dockable pane to the Revit user interface.

## Syntax (C#)
```csharp
public void RegisterDockablePane(
	DockablePaneId id,
	string title,
	IDockablePaneProvider provider
)
```

## Parameters
- **id** (`Autodesk.Revit.UI.DockablePaneId`) - Unique identifier for the new pane.
- **title** (`System.String`) - String to use for the pane caption.
- **provider** (`Autodesk.Revit.UI.IDockablePaneProvider`) - Your add-in's implementation of the IDockablePaneProvider interface.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if a dockable pane with identifier %id% has already been registered.

