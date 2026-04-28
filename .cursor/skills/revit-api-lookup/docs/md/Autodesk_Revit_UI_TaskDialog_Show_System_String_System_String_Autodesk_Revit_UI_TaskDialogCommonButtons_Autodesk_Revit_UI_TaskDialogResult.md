---
kind: method
id: M:Autodesk.Revit.UI.TaskDialog.Show(System.String,System.String,Autodesk.Revit.UI.TaskDialogCommonButtons,Autodesk.Revit.UI.TaskDialogResult)
zh: 取消隐藏、显示
source: html/8732a048-0abb-686d-b7fc-3f1c8f015b46.htm
---
# Autodesk.Revit.UI.TaskDialog.Show Method

**中文**: 取消隐藏、显示

Shows a task dialog with title, main instruction, common buttons and default buttons.

## Syntax (C#)
```csharp
public static TaskDialogResult Show(
	string title,
	string mainInstruction,
	TaskDialogCommonButtons buttons,
	TaskDialogResult defaultButton
)
```

## Parameters
- **title** (`System.String`) - The title of the task dialog.
- **mainInstruction** (`System.String`) - The main instruction of the task dialog.
- **buttons** (`Autodesk.Revit.UI.TaskDialogCommonButtons`) - The common buttons to be shown the task dialog.
- **defaultButton** (`Autodesk.Revit.UI.TaskDialogResult`) - The default button of the task dialog.

## Returns
The user's response to the task dialog.

