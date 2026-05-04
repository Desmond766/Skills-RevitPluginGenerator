---
kind: property
id: P:Autodesk.Revit.UI.DockablePaneState.TabBehind
source: html/05fde7c9-8b43-bb29-e37f-0386a00b2525.htm
---
# Autodesk.Revit.UI.DockablePaneState.TabBehind Property

Ignored unless %dockPosition% is Tabbed. The new pane will appear in a tab behind the specified existing pane ID.

## Syntax (C#)
```csharp
public DockablePaneId TabBehind { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: no dockable pane has been registered with identifier tabBehind.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

