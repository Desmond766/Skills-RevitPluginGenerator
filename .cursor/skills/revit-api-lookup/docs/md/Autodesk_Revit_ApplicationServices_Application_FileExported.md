---
kind: event
id: E:Autodesk.Revit.ApplicationServices.Application.FileExported
source: html/54ac62e1-a215-ba22-c19e-6ad3c37ccc7c.htm
---
# Autodesk.Revit.ApplicationServices.Application.FileExported Event

Subscribe to the FileExported event to be notified immediately after Revit has finished exporting files of formats supported by the API.

## Syntax (C#)
```csharp
public event EventHandler<FileExportedEventArgs> FileExported
```

## Remarks
This event is raised immediately after Revit has finished exporting files of formats supported by the API.
 It is raised even when file exporting failed or was cancelled (during FileExporting event). 
 Handlers of this event are permitted to make modifications to any document (including the active document),
 except for documents that are currently in read-only mode.
 Check the 'Status' field in event's argument to see whether the action itself was successful or not.
 If export is a part of 'Publish to Buzzsaw' command which consists of two parts â€“ export of a document followed by publishing it to a BuzzSaw server, the event status only reflects the result of the Export action. The publishing part of the command could still be cancelled or could fail after FileExported event is raised. This event is not cancellable, for the process of exporting file has already been finished. If the action was not successful, the document may not be modified and new transactions may not be started. The following API functions are not available for the current document during this event:
 Close () () () and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event.

