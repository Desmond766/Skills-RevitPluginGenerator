---
kind: method
id: M:Autodesk.Revit.UI.RibbonPanel.AddSlideOut
zh: 功能区
source: html/a456ce07-b3ef-9fe8-8234-b794d4db38da.htm
---
# Autodesk.Revit.UI.RibbonPanel.AddSlideOut Method

**中文**: 功能区

Adds a slideout to the current panel.

## Syntax (C#)
```csharp
public void AddSlideOut()
```

## Remarks
The slideout part of the panel can be shown by clicking on the arrow at the bottom of the panel.
After calling AddSlideOut(), any subsequent calls to add new items will add the new item(s) to the slideout.
The slideout part of the panel will be shown only if items are added after this call.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when a slide out panel is already added.

