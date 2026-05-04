---
kind: property
id: P:Autodesk.Revit.UI.TaskDialog.MainInstruction
zh: 提示、弹窗、消息框
source: html/03322859-aa16-1bef-e48d-aeb99ec6da1b.htm
---
# Autodesk.Revit.UI.TaskDialog.MainInstruction Property

**中文**: 提示、弹窗、消息框

The large primary text that appears at the top of a task dialog.

## Syntax (C#)
```csharp
public string MainInstruction { get; set; }
```

## Remarks
It should concisely sum up the problem or situation that is causing the message to display. Follow these guidelines:
 Every task dialog includes a main instruction. Text should not exceed three lines. Text should use plain language and be jargon free. Main instructions should be written in sentence format – normal capitalization and punctuation. Address the user directly as "you" when appropriate. When presented with multiple command link options the standard final line for the main instructions should be,
 "What do you want to do?" Revit will automatically break lines to make the message fit well. "\n" also breaks down to the next line. For a paragraph break, use "\n\n". Hyperlinks added to the main instructions will not be enabled when the dialog is shown on Vista.

