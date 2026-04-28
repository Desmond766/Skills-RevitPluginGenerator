---
kind: method
id: M:Autodesk.Revit.UI.UIDocument.RequestViewChange(Autodesk.Revit.DB.View)
source: html/a2e920d4-2849-282e-c25f-40a4d2cbef2d.htm
---
# Autodesk.Revit.UI.UIDocument.RequestViewChange Method

Requests an asynchronous change of the active view in the currently active document.

## Syntax (C#)
```csharp
public void RequestViewChange(
	View view
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The View.

## Remarks
This method requests to change the active view by posting a message asynchronously. 
 Unlike setting the ActiveView property, 
 this will not make the change in active view immediately. Instead the request will be posted 
 to occur when control returns to Revit from the API context. This method is permitted to change 
 the active view from the Idling event or an ExternalEvent callback. The active view cannot be changed when:
 There is an open transaction in the currently active document. IsModifiable is true. IsReadOnly is true. ViewActivating, ViewActivated, or any pre-event (such as DocumentSaving) is being handled.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - If the 'view' argument is NULL.
- **Autodesk.Revit.Exceptions.ArgumentException** - If the given view is not a valid view of the document; -or- If the given view is a template view; -or- If the given view is an internal view.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - If the given view is not from the currently active document; -or- If the active document is currently modifiable (i.e. with an active transaction); -or- If the active document is currently in read-only state; -or- During either ViewActivating or ViewActivated event; -or- During any pre-action kind of event, such as DocumentSaving, etc.

