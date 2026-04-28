---
kind: property
id: P:Autodesk.Revit.UI.TaskDialog.DefaultButton
zh: 提示、弹窗、消息框
source: html/db31a684-fbd0-ef77-3910-cc65a73e5b63.htm
---
# Autodesk.Revit.UI.TaskDialog.DefaultButton Property

**中文**: 提示、弹窗、消息框

The default button for the dialog.

## Syntax (C#)
```csharp
public TaskDialogResult DefaultButton { get; set; }
```

## Remarks
If DefaultButton is TaskDialogResult.None or its value does not correspond to any CommonButton or CommandLink in the dialog, 
then the first button in the dialog will be the default.

