---
kind: event
id: E:Autodesk.Revit.DB.Document.DocumentSaving
zh: 文档、文件
source: html/26a118b5-c583-a9b2-c935-c11b270e140e.htm
---
# Autodesk.Revit.DB.Document.DocumentSaving Event

**中文**: 文档、文件

Subscribe to the DocumentSaving event to be notified when Revit is just about to save a document.

## Syntax (C#)
```csharp
public event EventHandler<DocumentSavingEventArgs> DocumentSaving
```

## Remarks
This event is raised when Revit is just about to save the document.
 Note that the first save of a newly created document will raise DocumentSavingAs 
 rather than the DocumentSaving event. 
 Handlers of this event are permitted to make modifications to any document (including the active document),
 except for documents that are currently in read-only mode.
 This event is cancellable, except when it is raised during close of the application.
 Check the 'Cancellable' property of event's argument to see whether it is cancellable or not.
 When it is cancellable, call the 'Cancel()' method of event's argument to cancel it.
 Your application is responsible for providing feedback to the user about the reason for the cancellation. The following API functions are not available for the current document during this event:
 Close () () () and similar overloads. Save () () () . SaveAs(String) and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event. Another event DocumentSaved will be raised immediately after the document has been saved.

