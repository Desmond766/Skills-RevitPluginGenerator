---
kind: method
id: M:Autodesk.Revit.UI.TaskDialog.EnableDoNotShowAgain(System.String,System.Boolean,System.String)
zh: 提示、弹窗、消息框
source: html/b14f8805-cfa4-516e-1873-b284f82770d9.htm
---
# Autodesk.Revit.UI.TaskDialog.EnableDoNotShowAgain Method

**中文**: 提示、弹窗、消息框

Enables the "Do not show again" for a task dialog.

## Syntax (C#)
```csharp
public void EnableDoNotShowAgain(
	string dialogId,
	bool enableDoNotShow,
	string doNotShowText
)
```

## Parameters
- **dialogId** (`System.String`) - The non localized dialog identifier. It is used to store in Revit.ini the choice the user made the last time the dialog was shown.
- **enableDoNotShow** (`System.Boolean`) - The boolean to enable or disable the do not show me again functionality.
- **doNotShowText** (`System.String`) - The customized localized string that shows along with the do not show again checkbox.

## Remarks
Thrown if the TaskDialog also has VerificationText set as the two cannot coincide in the same TaskDialog. When enabled, the TaskDialog will contain a checkbox with the text specified to not show the task dialog again. By default a task dialog will not have this check box. If the user checks the check box, the next call to Show() for the indicated dialog id returns the choice the user made the last time the dialog was shown.

