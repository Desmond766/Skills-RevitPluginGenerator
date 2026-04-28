---
kind: property
id: P:Autodesk.Revit.UI.DockablePaneProviderData.InitialState
source: html/7bd17103-9aa2-591a-c6ee-0ac6a10a5bad.htm
---
# Autodesk.Revit.UI.DockablePaneProviderData.InitialState Property

The initial position of the docking pane.

## Syntax (C#)
```csharp
public DockablePaneState InitialState { get; set; }
```

## Remarks
This position will be used for the first Revit session in which the pane is registered; afterwards, the user is free 
 to reposition the pane, and the user's saved position will be remembered in future sessions.

