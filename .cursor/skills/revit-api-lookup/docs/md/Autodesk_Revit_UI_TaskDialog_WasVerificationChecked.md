---
kind: method
id: M:Autodesk.Revit.UI.TaskDialog.WasVerificationChecked
zh: 提示、弹窗、消息框
source: html/27321709-d5e0-64ce-b3a7-63e181fb7be5.htm
---
# Autodesk.Revit.UI.TaskDialog.WasVerificationChecked Method

**中文**: 提示、弹窗、消息框

Gets the status of the verification checkbox.

## Syntax (C#)
```csharp
public bool WasVerificationChecked()
```

## Returns
Whether the verification checkbox is checked.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the task dialog does not have verification checkbox or the task dialog is not shown yet.

