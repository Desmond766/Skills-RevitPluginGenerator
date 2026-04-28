---
kind: property
id: P:Autodesk.Revit.UI.TabbedDialogExtension.OnRestoreDefaultsAction
source: html/5934c168-a5bd-8b5a-7d64-fd4a199b5471.htm
---
# Autodesk.Revit.UI.TabbedDialogExtension.OnRestoreDefaultsAction Property

The restore defaults handler.

## Syntax (C#)
```csharp
public TabbedDialogAction OnRestoreDefaultsAction { get; set; }
```

## Remarks
This handler will be invoked when the "Restore Defaults" button in Revit options dialog is clicked
and the handler should apply only to options set on this page.
There is no "Restore Defaults" button in Revit options dialog if this property was set to Nothing nullptr a null reference ( Nothing in Visual Basic) .

