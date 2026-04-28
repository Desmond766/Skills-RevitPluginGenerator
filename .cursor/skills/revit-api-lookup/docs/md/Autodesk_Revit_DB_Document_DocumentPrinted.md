---
kind: event
id: E:Autodesk.Revit.DB.Document.DocumentPrinted
zh: 文档、文件
source: html/8d74cf02-9271-3c6c-00f5-bc7b48d52c56.htm
---
# Autodesk.Revit.DB.Document.DocumentPrinted Event

**中文**: 文档、文件

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

