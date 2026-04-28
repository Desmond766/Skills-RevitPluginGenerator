---
kind: event
id: E:Autodesk.Revit.ApplicationServices.ControlledApplication.FileImporting
source: html/5cd9ac35-6b1f-1084-c1f2-55d7dbc3b3ff.htm
---
# Autodesk.Revit.ApplicationServices.ControlledApplication.FileImporting Event

Subscribe to the FileImporting event to be notified when Revit is just about to import a file of format supported by the API.

## Syntax (C#)
```csharp
public event EventHandler<FileImportingEventArgs> FileImporting
```

## Remarks
This event is raised when Revit is just about to import a file of format supported by the API. 
 Handlers of this event are permitted to make modifications to any document (including the active document),
 except for documents that are currently in read-only mode.
 Event is cancellable. To cancel it, call the 'Cancel()' method in event's argument to True.
 Your application is responsible for providing feedback to the user about the reason for the cancellation. The following API functions are not available for the current document during this event:
 All overloads of Autodesk.Revit.DB.Document.Import() Close () () () and similar overloads. Save () () () . SaveAs(String) and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event. Another FileImported event will be raised immediately after file importing
 is finished.

