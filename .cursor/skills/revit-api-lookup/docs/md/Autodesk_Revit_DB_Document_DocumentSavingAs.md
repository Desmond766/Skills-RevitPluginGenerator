---
kind: event
id: E:Autodesk.Revit.DB.Document.DocumentSavingAs
zh: 文档、文件
source: html/e46e0d8f-5bcb-46bf-5def-03af68327b9e.htm
---
# Autodesk.Revit.DB.Document.DocumentSavingAs Event

**中文**: 文档、文件

Subscribe to the DocumentSavingAs event to be notified when Revit is just about to save the document with a new file name.

## Syntax (C#)
```csharp
public event EventHandler<DocumentSavingAsEventArgs> DocumentSavingAs
```

## Remarks
This event is raised when Revit is just about to save the document with a new file name.
 Note that the first save of a newly created document will raise DocumentSavingAs rather than DocumentSaving event.
Handlers of this event are permitted to make modifications to any document (including the active document),
 except for documents that are currently in read-only mode.
 This event is cancellable, except when it is raised during close of the application.
 Check the 'Cancellable' property of event's argument to see whether it is cancellable or not.
 When it is cancellable, call the 'Cancel()' method of event's argument to cancel it.
 Your application is responsible for providing feedback to the user about the reason for the cancellation. The following API functions are not available for the current document during this event:
 Close () () () and similar overloads. Save () () () . SaveAs(String) and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event. Another event DocumentSavedAs will be raised immediately after the document has been saved with a new file name.

