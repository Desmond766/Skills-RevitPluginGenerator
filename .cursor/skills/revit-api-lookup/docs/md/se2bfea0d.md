---
kind: property
id: P:Autodesk.Revit.UI.DockablePaneProviderData.FrameworkElementCreator
source: html/b44e3315-7fdb-f1bb-4ea2-2d22f382d301.htm
---
# Autodesk.Revit.UI.DockablePaneProviderData.FrameworkElementCreator Property

A creator that will be called for the pane if the FrameworkElement is not set.

## Syntax (C#)
```csharp
public IFrameworkElementCreator FrameworkElementCreator { get; set; }
```

## Remarks
This is more dynamic in nature and allows for embedding things like
 WebBrowser controls that cannot be cached for reuse in each pane invocation
 but rather needs creating each time.

