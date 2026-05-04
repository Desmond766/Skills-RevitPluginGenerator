---
kind: event
id: E:Autodesk.Revit.ApplicationServices.ControlledApplication.WorksharedOperationProgressChanged
source: html/9163633b-1939-f5a2-313a-ebb66aa062d0.htm
---
# Autodesk.Revit.ApplicationServices.ControlledApplication.WorksharedOperationProgressChanged Event

Subscribe to the WorksharedOperationProgressChanged to be notified when progress has changed during Collaboration for Revit's workshared operations: open model and synchronize with central.

## Syntax (C#)
```csharp
public event EventHandler<WorksharedOperationProgressChangedEventArgs> WorksharedOperationProgressChanged
```

## Remarks
This event is only supported for Collaboration for Revit and will not be raised for those operations occurring in local-worksharing and Revit Server workflow.
 Users may not change the document in the handler for this event.
 It is NOT recommended to do any time-consuming work when handling WorksharedOperationProgressChanged event. This can increase workshared operation time."
 Exception ModificationForbiddenException will be thrown if any document-modifying method is called during this event's handler.

