---
kind: event
id: E:Autodesk.Revit.ApplicationServices.Application.ViewPrinting
source: html/9dab43ee-41f1-99d3-6480-d32af1675ad4.htm
---
# Autodesk.Revit.ApplicationServices.Application.ViewPrinting Event

Subscribe to the ViewPrinting event to be notified when Revit is just about to print a view of the document.

## Syntax (C#)
```csharp
public event EventHandler<ViewPrintingEventArgs> ViewPrinting
```

## Remarks
This event is raised when Revit is just about to print a view of the document.
 If multiple views are combined to a single file, this event will be raised only once. 
 Handlers of this event are permitted to make modifications to any document (including the active document),
 except for documents that are currently in read-only mode.
 Event is not cancellable. The 'Cancellable' property of event's argument is always False. The following API functions are not available for the current document during this event:
 All overloads of Autodesk.Revit.DB.Document.Export() Autodesk.Revit.DB.Document.Print() Print () () () and similar overloads. SubmitPrint () () () and similar overloads. Close () () () and similar overloads. Save () () () . SaveAs(String) and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event. Another event ViewPrinted will be raised immediately after view printing
 is finished.

