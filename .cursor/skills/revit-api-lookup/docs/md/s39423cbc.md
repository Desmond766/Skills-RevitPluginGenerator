---
kind: event
id: E:Autodesk.Revit.ApplicationServices.ControlledApplication.DocumentCreated
source: html/89f514bf-f067-308d-0518-f050450bde72.htm
---
# Autodesk.Revit.ApplicationServices.ControlledApplication.DocumentCreated Event

Subscribe to the DocumentCreated event to be notified immediately after Revit has finished creating a new document.

## Syntax (C#)
```csharp
public event EventHandler<DocumentCreatedEventArgs> DocumentCreated
```

## Remarks
This event is raised immediately after Revit has finished creating a new document.
 It is raised even when document creation failed or was cancelled (during DocumentCreating event). 
 Handlers of this event are permitted to make modifications to any document (including the active document),
 except for documents that are currently in read-only mode.
 Check the 'Status' field in event's argument to see whether the action itself was successful or not.
 This event is not cancellable, for the process of document creation has already been finished. If the action was not successful, the document may not be modified and new transactions may not be started. The following API functions are not available for the current document during this event:
 Close () () () and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event.

