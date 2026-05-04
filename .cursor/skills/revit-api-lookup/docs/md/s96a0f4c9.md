---
kind: event
id: E:Autodesk.Revit.ApplicationServices.Application.DocumentReloadingLatest
source: html/f266e021-0f55-3671-f010-4b23128d6ca3.htm
---
# Autodesk.Revit.ApplicationServices.Application.DocumentReloadingLatest Event

Subscribe to the DocumentReloadingLatestEventArgs event to be notified when Revit is just about to reload latest changes from a central model.

## Syntax (C#)
```csharp
public event EventHandler<DocumentReloadingLatestEventArgs> DocumentReloadingLatest
```

## Remarks
This event is raised when Revit is just about to reload latest changes from a central model. 
 Handlers of this event are permitted to make modifications to any document (including the active document),
 except for documents that are currently in read-only mode.
 Event is cancellable. To cancel it, call the 'Cancel()' method in event's argument to True.
 Your application is responsible for providing feedback to the user about the reason for the cancellation. The following API functions are not available for the current document during this event:
 Close () () () and similar overloads. Save () () () . SaveAs(String) and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event. Another DocumentReloadingLatest event will be raised immediately after latest changes reloading from a central model
 is finished.

