---
kind: method
id: M:Autodesk.Revit.UI.UIApplication.GetRibbonPanels(System.String)
source: html/050f1ec2-e323-a09e-610f-5e31553b39bf.htm
---
# Autodesk.Revit.UI.UIApplication.GetRibbonPanels Method

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

