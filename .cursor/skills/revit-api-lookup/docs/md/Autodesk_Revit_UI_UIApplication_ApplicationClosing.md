---
kind: event
id: E:Autodesk.Revit.UI.UIApplication.ApplicationClosing
source: html/61068521-c216-3ab5-9d6e-28006fcfe0ae.htm
---
# Autodesk.Revit.UI.UIApplication.ApplicationClosing Event

Subscribe to the ApplicationClosing event to be notified when the Revit application is just about to be closed.

## Syntax (C#)
```csharp
public event EventHandler<ApplicationClosingEventArgs> ApplicationClosing
```

## Remarks
This event is raised when the Revit application is just about to be closed. Event is not cancellable. The 'Cancellable' property of event's argument is always False. No document may be modified at the time of the event. The sender object of this event is UIControlledApplication object.

