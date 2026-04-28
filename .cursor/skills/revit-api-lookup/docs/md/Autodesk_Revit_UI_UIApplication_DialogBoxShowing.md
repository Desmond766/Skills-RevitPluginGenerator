---
kind: event
id: E:Autodesk.Revit.UI.UIApplication.DialogBoxShowing
source: html/cb46ea4c-2b80-0ec2-063f-dda6f662948a.htm
---
# Autodesk.Revit.UI.UIApplication.DialogBoxShowing Event

Subscribe to the DialogBoxShowing event to be notified when Revit is just about to show a dialog box or a message box.

## Syntax (C#)
```csharp
public event EventHandler<DialogBoxShowingEventArgs> DialogBoxShowing
```

## Remarks
This event is raised when Revit is just about to show a dialog box or a message box. Event is not cancellable. The 'Cancellable' property of event's argument is always False. Depending on the type of the dialog that is being shown, the event's argument's type varies as follows:
 When it is a dialog box, the event's argument is an object of DialogBoxShowingEventArgs .
 When it is a message box, the event's argument is an object of MessageBoxShowingEventArgs ,which is subclass of DialogBoxShowingEventArgs.
 When it is a task dialog, the event's argument is an object of TaskDialogShowingEventArgs ,which is subclass of DialogBoxShowingEventArgs. No document may be modified during this event. The following API functions are not available for the current document during this event:
 Close () () () and similar overloads. Save () () () and similar overloads. SaveAs(String) and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event.

