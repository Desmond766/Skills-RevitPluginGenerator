---
kind: method
id: M:Autodesk.Revit.UI.UIApplication.GetRibbonPanels(Autodesk.Revit.UI.Tab)
source: html/0b079368-6f89-a359-eb7e-039ba25ac792.htm
---
# Autodesk.Revit.UI.UIApplication.GetRibbonPanels Method

Get all the custom Panels on a designated standard Revit tab.

## Syntax (C#)
```csharp
public virtual List<RibbonPanel> GetRibbonPanels(
	Tab tab
)
```

## Parameters
- **tab** (`Autodesk.Revit.UI.Tab`) - The tab on which the panels are located.

## Remarks
Built-in panels will not be included. This method is not supported in Macros.

