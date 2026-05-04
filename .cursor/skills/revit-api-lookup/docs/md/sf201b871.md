---
kind: property
id: P:Autodesk.Revit.UI.TaskDialog.VerificationText
zh: 提示、弹窗、消息框
source: html/4fe05f90-43ba-5641-4030-52de7c83a754.htm
---
# Autodesk.Revit.UI.TaskDialog.VerificationText Property

**中文**: 提示、弹窗、消息框

VerificationText is used to label the verification checkbox.

## Syntax (C#)
```csharp
public string VerificationText { get; set; }
```

## Remarks
Thrown if the TaskDialog has already enabled the Do not show message as the two cannot coincide in the same TaskDialog. 
If VerificationText is set, a checkbox with the text will be shown. You can get the response of checkbox by checking the return value of the WasVerificationChecked() method.

