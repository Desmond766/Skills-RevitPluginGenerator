---
kind: event
id: E:Autodesk.Revit.ApplicationServices.Application.FileImported
source: html/f72dee18-1a0d-dc0c-eb72-b75b0939c7c9.htm
---
# Autodesk.Revit.ApplicationServices.Application.FileImported Event

Subscribe to the FileImported event to be notified immediately after Revit has finished importing a file of format supported by the API.

## Syntax (C#)
```csharp
public event EventHandler<FileImportedEventArgs> FileImported
```

## Remarks
This event is raised immediately after Revit has finished importing a file of format supported by the API.
 It is raised even when file importing failed or was cancelled (during FileImporting event). 
 Handlers of this event are permitted to make modifications to any document (including the active document),
 except for documents that are currently in read-only mode.
 Check the 'Status' field in event's argument to see whether the action itself was successful or not. This event is not cancellable, for the process of importing has already been finished. If the action was not successful, the document may not be modified and new transactions may not be started. The following API functions are not available for the current document during this event:
 Close () () () and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event.

