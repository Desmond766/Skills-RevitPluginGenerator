---
kind: method
id: M:Autodesk.Revit.UI.UIControlledApplication.CreateRibbonPanel(System.String,System.String)
source: html/9d8c0d21-57d3-00c8-ce49-a2323cbce12b.htm
---
# Autodesk.Revit.UI.UIControlledApplication.CreateRibbonPanel Method

Create a new RibbonPanel on the specified tab.

## Syntax (C#)
```csharp
public virtual RibbonPanel CreateRibbonPanel(
	string tabName,
	string panelName
)
```

## Parameters
- **tabName** (`System.String`) - The name of the tab, on which the new panel will be created.
- **panelName** (`System.String`) - The name of the panel to be created.

## Remarks
This method will create a custom panel appending to the specified tab. This method is not supported in Macros.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - tabName or panelName is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - tabName or panelName is Empty.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Too many panels have been added to this tab (Maximum is 100).

