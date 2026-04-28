---
kind: type
id: T:Autodesk.Revit.UI.Events.TaskDialogShowingEventArgs
source: html/96cc0900-708b-5a2c-8d07-b2596ec20700.htm
---
# Autodesk.Revit.UI.Events.TaskDialogShowingEventArgs

The event arguments used by the DialogBoxShowing event when a Revit task dialog that prompts the user for some action is shown.

## Syntax (C#)
```csharp
public class TaskDialogShowingEventArgs : DialogBoxShowingEventArgs
```

## Remarks
When the application receives this object, a task dialog is about to be displayed in Revit that
 requires user interaction. The OverrideResult function can be used to cause the dialog
 to be dismissed and return a desired result code.

