---
kind: type
id: T:Autodesk.Revit.UI.TaskDialog
zh: 提示、弹窗、消息框
source: html/853afb57-7455-a636-9881-61a391118c16.htm
---
# Autodesk.Revit.UI.TaskDialog

**中文**: 提示、弹窗、消息框

A task dialog is a dialog box that can be used to display information and receive simple input from the user. It has a common set of controls 
that are arranged in a standard order to assure consistent look and feel.

## Syntax (C#)
```csharp
public class TaskDialog : APIObject
```

## Remarks
There are two ways to create and show a task dialog to the user. The first option is to construct the TaskDialog, set its properties individually, and use
the instance method Show() to show it to the user. The second is to use one of the static Show() methods to construct and show the dialog in one step. 
When you use the static methods only a subset of the options can be specified.
Please follow Revit standards to create task dialogs. The standards are listed in the remarks of each property or method.

