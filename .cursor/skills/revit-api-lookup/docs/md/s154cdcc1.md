---
kind: method
id: M:Autodesk.Revit.UI.UIControlledApplication.GetRibbonPanels(Autodesk.Revit.UI.Tab)
source: html/0c912777-d37d-a7e9-390b-622784beba63.htm
---
# Autodesk.Revit.UI.UIControlledApplication.GetRibbonPanels Method

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

