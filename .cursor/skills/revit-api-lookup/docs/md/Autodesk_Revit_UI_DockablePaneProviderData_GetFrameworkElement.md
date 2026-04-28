---
kind: method
id: M:Autodesk.Revit.UI.DockablePaneProviderData.GetFrameworkElement
source: html/845ed90c-0f08-6ff8-bc81-3be08814915e.htm
---
# Autodesk.Revit.UI.DockablePaneProviderData.GetFrameworkElement Method

Wrapper function that returns the FrameworkElement for this provider.

## Syntax (C#)
```csharp
public FrameworkElement GetFrameworkElement()
```

## Returns
FrameworkElement to use as the pane's user interface.

## Remarks
If an IFrameworkElementCreator is provided, that will be called to generate the element,
 otherwise, the FrameworkElement associated with the provider is returned.

