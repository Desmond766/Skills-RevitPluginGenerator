---
kind: property
id: P:Autodesk.Revit.UI.DockablePaneProviderData.EditorInteraction
source: html/916ab1bb-45a0-8cbf-482f-5c652dc1b06d.htm
---
# Autodesk.Revit.UI.DockablePaneProviderData.EditorInteraction Property

Defines the interaction this pane has with the Active Editor when the pane becomes active.

## Syntax (C#)
```csharp
public EditorInteraction EditorInteraction { get; set; }
```

## Remarks
Set to KeepAlive to keep the current editor active and
 keep active the current selection or Dismiss to dismiss
 the Editor and clear the active selection.
 Default is to KeepAlive the current editor.

