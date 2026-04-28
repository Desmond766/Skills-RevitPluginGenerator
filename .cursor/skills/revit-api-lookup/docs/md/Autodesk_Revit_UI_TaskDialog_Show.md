---
kind: method
id: M:Autodesk.Revit.UI.TaskDialog.Show
zh: 取消隐藏、显示
source: html/0d4bf9a6-4633-cb69-7580-ef2b8db1d05c.htm
---
# Autodesk.Revit.UI.TaskDialog.Show Method

**中文**: 取消隐藏、显示

Shows the task dialog.

## Syntax (C#)
```csharp
public TaskDialogResult Show()
```

## Returns
The user's response to the task dialog.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when 
the task dialog is shown out of main thread of Revit or when an extra checkbox and a verification checkbox are enabled at the same time.

