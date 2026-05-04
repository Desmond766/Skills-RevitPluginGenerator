---
kind: method
id: M:Autodesk.Revit.UI.UIApplication.CreateRibbonPanel(System.String,System.String)
source: html/5c22d48b-59b3-2599-7c7a-83257cddf0df.htm
---
# Autodesk.Revit.UI.UIApplication.CreateRibbonPanel Method

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

