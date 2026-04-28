---
kind: method
id: M:Autodesk.Revit.UI.UIDocument.UpdateAllOpenViews
source: html/5cc3231e-ee7e-e1fc-2bd6-d164da617954.htm
---
# Autodesk.Revit.UI.UIDocument.UpdateAllOpenViews Method

Update all open views in this document after elements have been changed, deleted, selected or de-selected.
 Graphics in the views are fully redrawn regardless of which elements have changed.

## Syntax (C#)
```csharp
public void UpdateAllOpenViews()
```

## Remarks
This function should only rarely be needed, but might be required when working with graphics drawn from outside of Revit's transactions and elements,
 for example, when using IDirectContext3DServer .
This function is potentially expensive as many views may be updated at once, including regeneration of view's geometry and redisplay of graphics.
 Thus for most situations it is recommended that API applications rely on the Revit application framework to update views more deliberately.

