---
kind: event
id: E:Autodesk.Revit.DB.Document.DocumentSavedAs
zh: 文档、文件
source: html/7ace570d-870f-be20-e493-e80ffa27f454.htm
---
# Autodesk.Revit.DB.Document.DocumentSavedAs Event

**中文**: 文档、文件

Subscribe to the DocumentSavedAs event to be notified immediately after Revit has finished saving document with a new file name.

## Syntax (C#)
```csharp
public event EventHandler<DocumentSavedAsEventArgs> DocumentSavedAs
```

## Remarks
This event is raised immediately after Revit has finished saving document with a new file name.
 Note that the first save of a newly created document will raise DocumentSavedAs rather than DocumentSaved event.
 It is raised even when document saving failed or was cancelled (during DocumentSavingAs event). 
 Handlers of this event are permitted to make modifications to any document (including the active document),
 except for documents that are currently in read-only mode.
 Check the 'Status' property in event's argument to see whether the action itself was successful or not. This event is not cancellable, for the process of saving document has already been finished. The following API functions are not available for the current document during this event:
 Close () () () and similar overloads. Save () () () . SaveAs(String) and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event.

