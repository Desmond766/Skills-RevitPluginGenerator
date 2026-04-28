---
kind: method
id: M:Autodesk.Revit.UI.TaskDialog.WasExtraCheckBoxChecked
zh: 提示、弹窗、消息框
source: html/bbfa2dab-94f9-96d5-157d-237810e708fb.htm
---
# Autodesk.Revit.UI.TaskDialog.WasExtraCheckBoxChecked Method

**中文**: 提示、弹窗、消息框

Gets the status of the extra checkbox.

## Syntax (C#)
```csharp
public bool WasExtraCheckBoxChecked()
```

## Returns
Whether the extra checkbox is checked.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the task dialog does not have an extra checkbox or the task dialog is not shown yet.

