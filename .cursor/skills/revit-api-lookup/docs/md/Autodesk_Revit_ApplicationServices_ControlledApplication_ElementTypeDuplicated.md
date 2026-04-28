---
kind: event
id: E:Autodesk.Revit.ApplicationServices.ControlledApplication.ElementTypeDuplicated
source: html/470b50f6-5f49-a585-4b00-13b4131fb0c2.htm
---
# Autodesk.Revit.ApplicationServices.ControlledApplication.ElementTypeDuplicated Event

Subscribe to the ElementTypeDuplicated event to be notified immediately after Revit has finished duplicating an element type.

## Syntax (C#)
```csharp
public event EventHandler<ElementTypeDuplicatedEventArgs> ElementTypeDuplicated
```

## Remarks
This event is raised immediately after Revit has finished duplicating an element type.
 It is raised even when duplicating an element type failed or was cancelled (during ElementTypeDuplicating event). 
 Handlers of this event are permitted to make modifications to any document (including the active document),
 except for documents that are currently in read-only mode.
 Check the 'Status' field in the event's argument to see whether the action itself was successful or not. This event is not cancellable, for the process of duplicating an element type has already been finished. If the action was not successful, the document may not be modified and new transactions may not be started. The following API functions are not available for the current document during this event:
 Close () () () and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event.

