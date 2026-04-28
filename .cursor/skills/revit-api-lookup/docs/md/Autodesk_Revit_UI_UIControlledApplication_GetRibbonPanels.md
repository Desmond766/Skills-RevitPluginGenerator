---
kind: method
id: M:Autodesk.Revit.UI.UIControlledApplication.GetRibbonPanels
source: html/f361edc1-cbf2-8334-32c8-dd5492f24435.htm
---
# Autodesk.Revit.UI.UIControlledApplication.GetRibbonPanels Method

Get all the custom Panels on Add-Ins tab of Revit.

## Syntax (C#)
```csharp
public virtual List<RibbonPanel> GetRibbonPanels()
```

## Remarks
The built-in panels won't be included and the panels added to tabs other than Add-Ins will not be included. 
This method is not supported in Macros.

