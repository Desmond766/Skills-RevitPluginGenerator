---
kind: method
id: M:Autodesk.Revit.UI.DockablePane.PaneIsRegistered(Autodesk.Revit.UI.DockablePaneId)
source: html/058ac1e7-900e-f310-e17a-d1eba04976e0.htm
---
# Autodesk.Revit.UI.DockablePane.PaneIsRegistered Method

Returns true if %id% refers to a built-in Revit dockable pane, or an add-in pane that has been properly registered with %Autodesk.Revit.UI.UIApplication.RegisterDockablePane%.

## Syntax (C#)
```csharp
public static bool PaneIsRegistered(
	DockablePaneId id
)
```

## Parameters
- **id** (`Autodesk.Revit.UI.DockablePaneId`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

