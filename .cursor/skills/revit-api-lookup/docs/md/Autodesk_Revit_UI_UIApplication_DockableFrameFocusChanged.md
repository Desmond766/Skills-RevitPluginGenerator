---
kind: event
id: E:Autodesk.Revit.UI.UIApplication.DockableFrameFocusChanged
source: html/f007d1f4-e911-60cf-3973-af1007b67ce2.htm
---
# Autodesk.Revit.UI.UIApplication.DockableFrameFocusChanged Event

Subscribe to this event to be notified when a Revit GenericDockableFrame has gained focus or lost focus in the Revit user interface.
 This event is called only for API-created GenericDockableFrames.

## Syntax (C#)
```csharp
public event EventHandler<DockableFrameFocusChangedEventArgs> DockableFrameFocusChanged
```

## Remarks
This event is raised when the GenericDockableFrame is just about to be active or inactive. Event is not cancellable. The 'Cancellable' property of event's argument is always False. No document may be modified at the time of the event. The following API functions are not available for the current document during this event:
 All overloads of Autodesk.Revit.DB.Document.Export() All overloads of Autodesk.Revit.DB.Document.Import() Autodesk::Revit::DB::Document::Print Print () () () and similar overloads. SubmitPrint () () () and similar overloads. Close () () () and similar overloads. Save () () () and similar overloads. SaveAs(String) and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event.

