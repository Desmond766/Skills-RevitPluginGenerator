---
kind: property
id: P:Autodesk.Revit.UI.TaskDialog.CommonButtons
zh: 提示、弹窗、消息框
source: html/3d625bdb-4227-a923-8a1a-fc8076f9d4f6.htm
---
# Autodesk.Revit.UI.TaskDialog.CommonButtons Property

**中文**: 提示、弹窗、消息框

The push buttons displayed in the task dialog.

## Syntax (C#)
```csharp
public TaskDialogCommonButtons CommonButtons { get; set; }
```

## Remarks
If no common button or CommandLink is added to the task dialog, the dialog will contain the Close common button by default. 
Revit task dialogs are following these conventions for commit button usage:
 Use a single Close button instead of a single OK button on informational messages. Use a question at the end of the Main Instruction with a Yes/No combo (or Yes/No/Cancel) instead of OK/Cancel. This should work 99% of the time. For example: "Are you sure you want to overwrite the file?" and use Yes/No buttons. Do not customize the button names unless there is a very good reason to do so. For example, "Are you sure you want to save the file?" would use Yes/No buttons and not Save/No or Save/Cancel.

