---
kind: method
id: M:Autodesk.Revit.UI.TaskDialog.Show(System.String,System.String)
zh: 取消隐藏、显示
source: html/5c8b40be-22c0-451e-14ed-b99ba5720a24.htm
---
# Autodesk.Revit.UI.TaskDialog.Show Method

**中文**: 取消隐藏、显示

Shows a task dialog with title, main instruction and a Close button.

## Syntax (C#)
```csharp
public static TaskDialogResult Show(
	string title,
	string mainInstruction
)
```

## Parameters
- **title** (`System.String`) - The title of the task dialog.
- **mainInstruction** (`System.String`) - The main instruction of the task dialog.

## Returns
The user's response to the task dialog.

