---
kind: event
id: E:Autodesk.Revit.ApplicationServices.Application.ElementTypeDuplicating
source: html/d8bf6d7a-9d18-9f9d-85ef-f2507710759e.htm
---
# Autodesk.Revit.ApplicationServices.Application.ElementTypeDuplicating Event

Subscribe to the ElementTypeDuplicating event to be notified when Revit is just about to duplicate an element type.

## Syntax (C#)
```csharp
public event EventHandler<ElementTypeDuplicatingEventArgs> ElementTypeDuplicating
```

## Remarks
This event is raised when Revit is just about to duplicate an element type. Event is cancellable. To cancel it, call the 'Cancel()' method in event's argument to True.
 Your application is responsible for providing feedback to the user about the reason for the cancellation. The following API functions are not available for the current document during this event:
 All overloads of Autodesk.Revit.DB.Document.Import() Close () () () and similar overloads. Save () () () . SaveAs(String) and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event. Another ElementTypeDuplicated event will be raised immediately after duplicating an element type is finished.

