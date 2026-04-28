---
kind: event
id: E:Autodesk.Revit.ApplicationServices.Application.DocumentReloadedLatest
source: html/83f69554-54d6-1632-fb6c-81edf0280d33.htm
---
# Autodesk.Revit.ApplicationServices.Application.DocumentReloadedLatest Event

Subscribe to the DocumentReloadedLatestEventArgs event to be notified immediately after Revit has finished reloading a document with central model.

## Syntax (C#)
```csharp
public event EventHandler<DocumentReloadedLatestEventArgs> DocumentReloadedLatest
```

## Remarks
This event is raised immediately after Revit has finished reloading latest changes from a central model.
 It is raised even when document reloading latest changes from a central model failed or was cancelled (during DocumentReloadingLatest event). 
 Handlers of this event are permitted to make modifications to any document (including the active document),
 except for documents that are currently in read-only mode.
 Check the 'Status' field in event's argument to see whether the action itself was successful or not. This event is not cancellable, for the process of reloading latest changes from a central model has already been finished. If the action was not successful, the document may not be modified and new transactions may not be started. The following API functions are not available for the current document during this event:
 Close () () () and similar overloads. Save () () () . SaveAs(String) and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event.

