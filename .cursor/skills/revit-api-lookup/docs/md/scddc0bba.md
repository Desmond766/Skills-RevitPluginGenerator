---
kind: type
id: T:Autodesk.Revit.DB.WorksharingUtils
source: html/ae7857a0-4e9b-f9c1-84c7-8b250af68068.htm
---
# Autodesk.Revit.DB.WorksharingUtils

A static class that contains utility functions related to worksharing.

## Syntax (C#)
```csharp
public class WorksharingUtils : IDisposable
```

## Remarks
Return values from inquiries about the worksharing status of elements or worksets
 rely on local caching of information from the central model so it is possible that the
 information is out of date. Because of this, the return value is suitable for reporting to an
 interactive user (e.g. via a mechanism similar to Worksharing display mode), but cannot be considered
 a reliable indication of whether the element can be immediately edited by the application. To make an immediate
 attempt to edit elements, use [!:CheckoutElements()] and check the return status,
 then confirm if the elements are up to date. In addition, information about the current user may not be
 reliable while Revit is in the middle of an editing transaction. For example,
 if you move an unowned wall from an unowned workset to a workset you own,
 then before you explicitly or Revit automatically checks out the wall for you,
 GetCheckoutStatus() might erroneously tell you CheckoutStatus.OwnedByCurrentUser
 because although the official (as seen in central and by other users) owner is no one,
 locally it looks like you already own it since it belongs to a workset you own. For operations that interact with central (as opposed to use only cached values),
 Revit might opportunistically refresh some editing permissions or check the status of editing requests. Some useful definitions to keep in mind follow:
 The owner of a workset: the user who has the Workset checked out; this could be nobody (the empty string). The borrower of an element: the user who has explicitly checked out ("borrowed") the Element;
 this could be nobody. The owner of an element: If element is borrowed (i.e. explicitly checked out),
 then the element's owner is the borrower, otherwise it is the owner or the workset containing the element.

