---
kind: method
id: M:Autodesk.Revit.UI.DockablePane.#ctor(Autodesk.Revit.UI.DockablePaneId)
source: html/ce2c0837-4700-1990-0c89-73d49a3db889.htm
---
# Autodesk.Revit.UI.DockablePane.#ctor Method

Gets the pane with identifier %id%.

## Syntax (C#)
```csharp
public DockablePane(
	DockablePaneId id
)
```

## Parameters
- **id** (`Autodesk.Revit.UI.DockablePaneId`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - no dockable pane has been registered with identifier id.
 -or-
 the dockable pane with identifier id has not been created yet.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

