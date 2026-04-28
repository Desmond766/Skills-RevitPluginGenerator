---
kind: property
id: P:Autodesk.Revit.UI.DockablePaneProviderData.VisibleByDefault
source: html/86d9fd32-9b45-d1df-d444-f4d71874e727.htm
---
# Autodesk.Revit.UI.DockablePaneProviderData.VisibleByDefault Property

Controls the default visibility of the pane upon the first time
 the pane/plugin is loaded into Revit.

## Syntax (C#)
```csharp
public bool VisibleByDefault { get; set; }
```

## Remarks
By default, panes will be created and shown in the Revit UI when
 Revit is launched for the first time. Subsequent loads of the Revit
 UI will determine the visibility of the panes based upon there state
 at the close of the previous Revit session. Providers can set this
 to false if they wish there panes to NOT be shown by default.

