---
kind: property
id: P:Autodesk.Revit.UI.TaskDialog.ExpandedContent
zh: 提示、弹窗、消息框
source: html/3aff0677-7049-fe66-f37b-fcfbd78f3872.htm
---
# Autodesk.Revit.UI.TaskDialog.ExpandedContent Property

**中文**: 提示、弹窗、消息框

ExpandedContent is hidden by default and will display at the bottom of the task dialog when the "Show details" button is pressed.

## Syntax (C#)
```csharp
public string ExpandedContent { get; set; }
```

## Remarks
If added to a dialog, a Show/Hide toggle button displays at the bottom of the task dialog. The Expanded Content is hidden by default. 
This area is used when even more information needs to be relayed to the user than space allows. It is rarely used, but can be used for showing technical 
information passed through in a variable, for example back-end error information, lists of files, etc. 
Variable information should always be introduced with a lead-in sentence.

