---
kind: method
id: M:Autodesk.Revit.DB.WorksharingUtils.CheckoutElements(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/5553298f-e8a3-13f1-3f1b-f3505e82eb5c.htm
---
# Autodesk.Revit.DB.WorksharingUtils.CheckoutElements Method

Obtains ownership for the current user of as many specified elements as possible.

## Syntax (C#)
```csharp
public static ICollection<ElementId> CheckoutElements(
	Document document,
	ICollection<ElementId> elementsToCheckout
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the elements.
- **elementsToCheckout** (`System.Collections.Generic.ICollection < ElementId >`) - The ids of the elements to attempt to check out.

## Returns
The ids of all specified elements that are now owned (but possibly out of date),
 including all that were owned prior to the function call.

## Remarks
For best performance, checkout all elements in one big call, rather than many small calls. Revit may check out additional elements that are needed to check out the elements you requested.
 For example, if you request an element that is in a group, Revit will check out the entire group. When there comes a contention error when locking the central model, this API would wait and retry
 endlessly until getting the lock of the central model.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a workshared document.
 -or-
 document is not a primary document, it is a linked document.
 -or-
 One or more elements in elementsToCheckout do not exist in the document.
 -or-
 Saving is not allowed in the current application mode.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.CentralFileCommunicationException** - Editing permissions for the file-based central model could not be accessed for write,
 e.g. the network is down, central is missing, or central is read-only.
- **Autodesk.Revit.Exceptions.CentralModelAccessDeniedException** - Access to the central model was denied. A possible reason is because the model was under maintenance.
- **Autodesk.Revit.Exceptions.CentralModelContentionException** - Editing permissions for the central model are locked and the last attempt to lock was canceled.
 -or-
 The central model is being accessed by another client.
- **Autodesk.Revit.Exceptions.CentralModelException** - An error has occurred while checking out worksets or elements.
 -or-
 The central model is overwritten by other user.
 -or-
 The central model is missing.
 -or-
 An internal error happened on the central model, please contact the server administrator.
- **Autodesk.Revit.Exceptions.CentralModelVersionArchivedException** - Last central version merged into the local model has been archived in the central model.
 This exception could only be thrown from cloud models.
- **Autodesk.Revit.Exceptions.RevitServerCommunicationException** - The server-based central model could not be accessed
 because of a network communication error.
- **Autodesk.Revit.Exceptions.RevitServerInternalException** - An internal error happened on the server, please contact the server administrator.

