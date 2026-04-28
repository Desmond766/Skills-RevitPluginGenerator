---
kind: method
id: M:Autodesk.Revit.UI.UIControlledApplication.RegisterDockablePane(Autodesk.Revit.UI.DockablePaneId,System.String,Autodesk.Revit.UI.IDockablePaneProvider)
source: html/3c913e04-4444-319e-04bb-61a4784b5d4d.htm
---
# Autodesk.Revit.UI.UIControlledApplication.RegisterDockablePane Method

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

