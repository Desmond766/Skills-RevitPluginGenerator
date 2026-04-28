---
kind: method
id: M:Autodesk.Revit.UI.UIControlledApplication.CreateRibbonTab(System.String)
source: html/8ce17489-75ee-ae81-306d-58f9c505c80c.htm
---
# Autodesk.Revit.UI.UIControlledApplication.CreateRibbonTab Method

Creates a new tab on the Revit user interface.

## Syntax (C#)
```csharp
public virtual void CreateRibbonTab(
	string tabName
)
```

## Parameters
- **tabName** (`System.String`) - The name of the tab to be created.

## Remarks
This method will create a custom tab at the end of the list of static tabs. If multiple tabs are added, they will be shown in the order added. This method is not supported in Macros.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - tabName or panelName is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - tabName or panelName is Empty or the tab name duplicates the name of another tab in the Revit UI.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Too many custom tabs have been created in this session. (Maximum is 20).

