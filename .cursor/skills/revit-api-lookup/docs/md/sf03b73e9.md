---
kind: property
id: P:Autodesk.Revit.UI.TaskDialog.EnableMarqueeProgressBar
zh: 提示、弹窗、消息框
source: html/b3a3412b-1f70-f7a6-a97f-12c51eaff104.htm
---
# Autodesk.Revit.UI.TaskDialog.EnableMarqueeProgressBar Property

**中文**: 提示、弹窗、消息框

Enables a marquee style progress bar to be displayed in the TaskDialog.

## Syntax (C#)
```csharp
public bool EnableMarqueeProgressBar { get; set; }
```

## Remarks
When true, the TaskDialog will display a progress bar that has an indeterminate start and stop. A progress bar is a window that an application can use to indicate the progress of a lengthy operation. It consists of a rectangle that is animated as an operation progresses. The animation continues until the TaskDialog is closed. The default value is false.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the TaskDialog also has ExtraCheckBoxText set as the two cannot coincide in the same TaskDialog.

