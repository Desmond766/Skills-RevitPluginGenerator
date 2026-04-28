---
kind: event
id: E:Autodesk.Revit.UI.UIApplication.ViewActivating
source: html/ee4212fa-e41d-5cb5-ddc3-e31bc42db881.htm
---
# Autodesk.Revit.UI.UIApplication.ViewActivating Event

Subscribe to the ViewActivating event to be notified when Revit is just about to activate a view of a document.

## Syntax (C#)
```csharp
public event EventHandler<ViewActivatingEventArgs> ViewActivating
```

## Remarks
This event is raised when Revit is just about to activate a view of the document. Event is not cancellable. The 'Cancellable' property of event's argument is always False.
 Your application is responsible for providing feedback to the user about the reason for the cancellation. The document may be modified during this event. The following API functions are not available for the current document during this event:
 Close () () () and similar overloads. Save () () () and similar overloads. SaveAs(String) and similar overloads. Exception InvalidOperationException will be thrown if any of the above
 methods is called during this event. Another ViewActivated event will be raised immediately after view
 activating is finished.

