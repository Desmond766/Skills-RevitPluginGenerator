---
kind: event
id: E:Autodesk.Revit.ApplicationServices.Application.ViewExporting
source: html/0968f8d8-2f4a-619e-f085-3c8aedcb1775.htm
---
# Autodesk.Revit.ApplicationServices.Application.ViewExporting Event

Subscribe to the ViewExporting event to be notified when Revit is just about to export a view of the document.

## Syntax (C#)
```csharp
public event EventHandler<ViewExportingEventArgs> ViewExporting
```

## Remarks
This event is raised when Revit is just about to export a view of the document.
 It is raised only during accelerated export jobs, in which views are exported in parallel using a background process.
 Accelerated export only occurs when exporting to DWF formats and not combining views into a single file. 
 Handlers of this event are permitted to make modifications to any document (including the active document),
 except for documents that are currently in read-only mode.
 Event is not cancellable. The 'Cancellable' property of event's argument is always False. The following API functions are not available for the current document during this event:
 All overloads of Autodesk.Revit.DB.Document.Export() Autodesk.Revit.DB.Document.Print() Print () () () and similar overloads. SubmitPrint () () () and similar overloads. Close () () () and similar overloads. Save () () () . SaveAs(String) and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event. Another event ViewExported will be raised immediately after view exporting
 is finished.

