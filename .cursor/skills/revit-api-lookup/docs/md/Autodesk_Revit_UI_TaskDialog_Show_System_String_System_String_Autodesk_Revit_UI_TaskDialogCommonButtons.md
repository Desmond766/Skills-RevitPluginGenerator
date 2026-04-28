---
kind: method
id: M:Autodesk.Revit.UI.TaskDialog.Show(System.String,System.String,Autodesk.Revit.UI.TaskDialogCommonButtons)
zh: 取消隐藏、显示
source: html/1c061a6b-e994-0bad-162b-34b0c9f663ba.htm
---
# Autodesk.Revit.UI.TaskDialog.Show Method

**中文**: 取消隐藏、显示

Shows a task dialog with title, main instruction and common buttons.

## Syntax (C#)
```csharp
public static TaskDialogResult Show(
	string title,
	string mainInstruction,
	TaskDialogCommonButtons buttons
)
```

## Parameters
- **title** (`System.String`) - The title of the task dialog.
- **mainInstruction** (`System.String`) - The main instruction of the task dialog.
- **buttons** (`Autodesk.Revit.UI.TaskDialogCommonButtons`) - The common buttons to be shown the task dialog.

## Returns
The user's response to the task dialog.

