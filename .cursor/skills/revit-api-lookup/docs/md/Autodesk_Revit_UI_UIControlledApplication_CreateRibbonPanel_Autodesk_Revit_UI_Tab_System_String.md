---
kind: method
id: M:Autodesk.Revit.UI.UIControlledApplication.CreateRibbonPanel(Autodesk.Revit.UI.Tab,System.String)
source: html/8250b04b-f13c-cdd0-fab1-7bad756d746d.htm
---
# Autodesk.Revit.UI.UIControlledApplication.CreateRibbonPanel Method

Create a new RibbonPanel on the designated standard Revit tab.

## Syntax (C#)
```csharp
public virtual RibbonPanel CreateRibbonPanel(
	Tab tab,
	string panelName
)
```

## Parameters
- **tab** (`Autodesk.Revit.UI.Tab`) - The target tab, on which the new panel will be created.
- **panelName** (`System.String`) - The name of the panel to be created.

## Remarks
This method will create a custom panel appending to the specified tab. This method is not supported in Macros.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - panelName is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - panelName is Empty or the tab is not valid.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - If more than 100 panels were created or the tab cannot be found.

