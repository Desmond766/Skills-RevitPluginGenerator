---
kind: event
id: E:Autodesk.Revit.UI.UIControlledApplication.ApplicationClosing
source: html/98344bdb-5bdd-443a-bb31-ae21ded5fe77.htm
---
# Autodesk.Revit.UI.UIControlledApplication.ApplicationClosing Event

Subscribe to the ApplicationClosing event to be notified when the Revit application is just about to be closed.

## Syntax (C#)
```csharp
public event EventHandler<ApplicationClosingEventArgs> ApplicationClosing
```

## Remarks
This event is raised when the Revit application is just about to be closed. Event is not cancellable. The 'Cancellable' property of event's argument is always False. No document may be modified at the time of the event. The sender object of this event is UIControlledApplication object.

