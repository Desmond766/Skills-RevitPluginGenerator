---
kind: method
id: M:Autodesk.Revit.UI.UIApplication.GetRibbonPanels
source: html/a360da3d-94a3-4521-ee55-4797112da02d.htm
---
# Autodesk.Revit.UI.UIApplication.GetRibbonPanels Method

Get all the custom Panels on Add-Ins tab of Revit.

## Syntax (C#)
```csharp
public virtual List<RibbonPanel> GetRibbonPanels()
```

## Remarks
The built-in panels won't be included and the panels added to tabs other than Add-Ins will not be included. 
This method is not supported in Macros.

