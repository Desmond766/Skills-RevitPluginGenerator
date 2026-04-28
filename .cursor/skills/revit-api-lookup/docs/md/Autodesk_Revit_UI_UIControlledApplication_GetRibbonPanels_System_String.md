---
kind: method
id: M:Autodesk.Revit.UI.UIControlledApplication.GetRibbonPanels(System.String)
source: html/249b272e-b296-d246-4862-8562270295f0.htm
---
# Autodesk.Revit.UI.UIControlledApplication.GetRibbonPanels Method

Get all the custom Panels on a designated Revit tab.

## Syntax (C#)
```csharp
public virtual List<RibbonPanel> GetRibbonPanels(
	string tabName
)
```

## Parameters
- **tabName** (`System.String`) - The name of the tab on which the panels are located.

## Remarks
Built-in panels will not be included. tabName must be the name of one of the tabs added 
by CreateRibbonTab(String) . 
This method is not supported in Macros.

