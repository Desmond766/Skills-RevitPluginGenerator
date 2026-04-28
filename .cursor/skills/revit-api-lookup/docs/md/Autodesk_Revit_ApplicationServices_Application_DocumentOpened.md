---
kind: event
id: E:Autodesk.Revit.ApplicationServices.Application.DocumentOpened
source: html/b9415c2d-442e-f61d-aafa-de31cce7959b.htm
---
# Autodesk.Revit.ApplicationServices.Application.DocumentOpened Event

Subscribe to the DocumentOpened event to be notified immediately after Revit has finished opening a document.

## Syntax (C#)
```csharp
public event EventHandler<DocumentOpenedEventArgs> DocumentOpened
```

## Remarks
This event is raised immediately after Revit has finished opening a document.
 It is raised even when document opening failed or was cancelled (during DocumentOpening event). 
 Handlers of this event are permitted to make modifications to any document (including the active document),
 except for documents that are currently in read-only mode.
 Check the 'Status' field in event's argument to see whether the action itself was successful or not. This event is not cancellable, for the process of opening document has already been finished. If the action was not successful, the document may not be modified and new transactions may not be started. The following API functions are not available for the current document during this event:
 Close () () () and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event.

