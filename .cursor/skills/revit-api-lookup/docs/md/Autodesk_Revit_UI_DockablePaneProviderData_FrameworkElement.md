---
kind: property
id: P:Autodesk.Revit.UI.DockablePaneProviderData.FrameworkElement
source: html/3b088335-98d9-ddd1-a9c1-a861e7bff9ed.htm
---
# Autodesk.Revit.UI.DockablePaneProviderData.FrameworkElement Property

The Windows Presentation Framework object containing the pane's user interface.

## Syntax (C#)
```csharp
public FrameworkElement FrameworkElement { get; set; }
```

## Remarks
Using a System.Windows.Controls.Page is recommended. This can be null, in which case
 it is assumed an IFrameworkElementCreator is provided to create the element on demand.

