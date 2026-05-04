---
kind: event
id: E:Autodesk.Revit.ApplicationServices.Application.DocumentPrinting
source: html/86546cf5-eb2f-ffd7-3931-fc361f1264e2.htm
---
# Autodesk.Revit.ApplicationServices.Application.DocumentPrinting Event

Subscribe to the DocumentPrinting event to be notified when Revit is just about to print a view or ViewSet of the document.

## Syntax (C#)
```csharp
public event EventHandler<DocumentPrintingEventArgs> DocumentPrinting
```

## Remarks
This event is raised when Revit is just about to print a view or ViewSet of the document. 
 Handlers of this event are permitted to make modifications to any document (including the active document),
 except for documents that are currently in read-only mode.
 Event is cancellable. To cancel it, call the 'Cancel()' method of event's argument to True.
 Your application is responsible for providing feedback to the user about the reason for the cancellation. The following API functions are not available for current document during this event:
 All overloads of Autodesk.Revit.DB.Document.Export() Autodesk::Revit::DB::Document::Print Print () () () and similar overloads. SubmitPrint () () () and similar overloads. Close () () () and similar overloads. Save () () () . SaveAs(String) and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event. After this event, for each view being printed, ViewPrinting and ViewPrinted events will be raised.
 Another event DocumentPrinted will be raised immediately after document printing
 is finished.

