---
kind: event
id: E:Autodesk.Revit.DB.Document.DocumentPrinting
zh: 文档、文件
source: html/77aa9939-8f41-1725-80dc-864ca1f7a49c.htm
---
# Autodesk.Revit.DB.Document.DocumentPrinting Event

**中文**: 文档、文件

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

