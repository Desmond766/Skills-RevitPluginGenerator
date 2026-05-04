---
kind: event
id: E:Autodesk.Revit.DB.Document.ViewPrinted
zh: 文档、文件
source: html/ace39293-a976-d22b-4798-42bb8e82b307.htm
---
# Autodesk.Revit.DB.Document.ViewPrinted Event

**中文**: 文档、文件

Subscribe to the ViewPrinted event to be notified immediately after Revit has finished printing a view of the document.

## Syntax (C#)
```csharp
public event EventHandler<ViewPrintedEventArgs> ViewPrinted
```

## Remarks
This event is raised immediately after Revit has finished printing a view of the document.
 If multiple views are combined to a single file, this event will be raised only once.
 It is raised even when view printing failed. 
 Handlers of this event are permitted to make modifications to any document (including the active document),
 except for documents that are currently in read-only mode.
 Check the 'Status' field in event's argument to see whether the action was successful or not. This event is not cancellable, for the process of view printing has already been finished. If the action was not successful, the document may not be modified and new transactions may not be started. The following API functions are not available for the current document during this event:
 Close () () () and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event.

