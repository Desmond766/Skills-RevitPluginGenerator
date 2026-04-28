---
kind: property
id: P:Autodesk.Revit.UI.TaskDialog.ExtraCheckBoxText
zh: 提示、弹窗、消息框
source: html/00a6d114-9937-11c6-f872-d987157a0d41.htm
---
# Autodesk.Revit.UI.TaskDialog.ExtraCheckBoxText Property

**中文**: 提示、弹窗、消息框

ExtraCheckBoxText is used to label the extra checkbox.

## Syntax (C#)
```csharp
public string ExtraCheckBoxText { get; set; }
```

## Remarks
If ExtraCheckBoxText is set, a checkbox with the text will be shown. You can get the response of checkbox by checking the return value of the WasExtraCheckBoxChecked() method.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the TaskDialog also has EnableMarqueeProgressBar set as the two cannot coincide in the same TaskDialog.

