---
kind: event
id: E:Autodesk.Revit.ApplicationServices.Application.DocumentPrinted
source: html/0846d2d2-5eff-0df2-cfdc-50378114a1e3.htm
---
# Autodesk.Revit.ApplicationServices.Application.DocumentPrinted Event

Subscribe to the DocumentPrinted event to be notified immediately after Revit has finished printing a view or ViewSet of the document.

## Syntax (C#)
```csharp
public event EventHandler<DocumentPrintedEventArgs> DocumentPrinted
```

## Remarks
This event is raised immediately after Revit has finished printing a view or ViewSet of the document.
 It is raised even when document printing failed or was cancelled (during DocumentPriting event). 
 Handlers of this event are permitted to make modifications to any document (including the active document),
 except for documents that are currently in read-only mode.
 Check the 'Status' field in event's argument to see whether the action itself was successful or not. This event is not cancellable, for the process of printing has already been finished. If the action was not successful, the document may not be modified and new transactions may not be started. The following API functions are not available for the current document during this event:
 Close () () () and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event.

