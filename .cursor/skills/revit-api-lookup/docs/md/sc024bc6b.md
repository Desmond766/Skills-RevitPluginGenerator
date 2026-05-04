---
kind: property
id: P:Autodesk.Revit.UI.TabbedDialogExtension.OnCancelAction
source: html/8c446f83-d4e5-36a8-7af2-f380c50ec607.htm
---
# Autodesk.Revit.UI.TabbedDialogExtension.OnCancelAction Property

The cancel handler.

## Syntax (C#)
```csharp
public TabbedDialogAction OnCancelAction { get; set; }
```

## Remarks
This handler will be invoked when the "Cancel" button in Revit options dialog is clicked. 
The Revit options dialog will be closed directly if this property was set to Nothing nullptr a null reference ( Nothing in Visual Basic) .

