---
kind: property
id: P:Autodesk.Revit.UI.TaskDialog.MainIcon
zh: 提示、弹窗、消息框
source: html/c249e25a-97a9-f869-c4a6-97a0a34fc9f9.htm
---
# Autodesk.Revit.UI.TaskDialog.MainIcon Property

**中文**: 提示、弹窗、消息框

The icon shown in the task dialog.

## Syntax (C#)
```csharp
public TaskDialogIcon MainIcon { get; set; }
```

## Remarks
There is no icon by default. 
Task dialogs in Revit rarely use icons, to reduce the visual clutter shown to the user. Only one icon can be used 
in the task dialog, the Warning (!) icon, and it should be used only when there is a risk of data loss or 
significant time lost. If there is no data loss or time lost as a possible result of the message, do not use the icon.

