---
kind: event
id: E:Autodesk.Revit.UI.UIApplication.ViewActivated
source: html/b208aae7-5cbf-21b4-b70e-af2e63ece383.htm
---
# Autodesk.Revit.UI.UIApplication.ViewActivated Event

Subscribe to the ViewActivated event to be notified immediately after Revit has finished activating a view of a document.

## Syntax (C#)
```csharp
public event EventHandler<ViewActivatedEventArgs> ViewActivated
```

## Remarks
This event is raised immediately after Revit has finished activating a view of the document.
 It is raised even when view activating failed or was cancelled (during ViewActivating event). Check the 'Status' field in event's argument to see whether the action itself was successful or not. This event is not cancellable, for the process of view activating has already been finished. The document may be modified during this event. The following API functions are not available for the current document during this event:
 Close () () () and similar overloads. Save () () () and similar overloads. SaveAs(String) and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event.

