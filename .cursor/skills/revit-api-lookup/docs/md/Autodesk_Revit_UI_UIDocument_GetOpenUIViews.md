---
kind: method
id: M:Autodesk.Revit.UI.UIDocument.GetOpenUIViews
source: html/1ac8b262-9085-07e9-cef6-85377e8c70f3.htm
---
# Autodesk.Revit.UI.UIDocument.GetOpenUIViews Method

Get a list of all open view windows in the Revit user interface.

## Syntax (C#)
```csharp
public IList<UIView> GetOpenUIViews()
```

## Remarks
A sheet view with an activated viewport will return the view associated with the activated viewport, not the sheet view.

