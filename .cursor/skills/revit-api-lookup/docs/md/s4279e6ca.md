---
kind: method
id: M:Autodesk.Revit.UI.UIApplication.CreateRibbonPanel(System.String)
source: html/17555f25-1afe-db1a-ebd5-845a41c4b28b.htm
---
# Autodesk.Revit.UI.UIApplication.CreateRibbonPanel Method

Create a new RibbonPanel on the Add-Ins tab.

## Syntax (C#)
```csharp
public virtual RibbonPanel CreateRibbonPanel(
	string panelName
)
```

## Parameters
- **panelName** (`System.String`) - The name of the panel to be created.

## Remarks
This method will create a custom panel appending to the Revit AddIns tab. This method is not supported in Macros.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - panelName is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - panelName is Empty.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - If more than 100 panels were created.

