---
kind: event
id: E:Autodesk.Revit.ApplicationServices.ControlledApplication.FileExporting
source: html/c1f11a68-7712-17bf-dde3-04a077a7e6cf.htm
---
# Autodesk.Revit.ApplicationServices.ControlledApplication.FileExporting Event

Subscribe to the FileExporting event to be notified when Revit is just about to export files of formats supported by the API.

## Syntax (C#)
```csharp
public event EventHandler<FileExportingEventArgs> FileExporting
```

## Remarks
This event is raised when Revit is just about to export files of formats supported by the API. 
 Handlers of this event are permitted to make modifications to any document (including the active document),
 except for documents that are currently in read-only mode.
 Event is cancellable. To cancel it, call the 'Cancel()' method in event's argument to True.
 Your application is responsible for providing feedback to the user about the reason for the cancellation. The following API functions are not available for the current document during this event:
 All overloads of Autodesk.Revit.DB.Document.Export() Autodesk.Revit.Document.Print() Print () () () and similar overloads. SubmitPrint () () () and similar overloads. Close () () () and similar overloads. Save () () () . SaveAs(String) and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event. Another FileExported event will be raised immediately after file exporting
 is finished.

