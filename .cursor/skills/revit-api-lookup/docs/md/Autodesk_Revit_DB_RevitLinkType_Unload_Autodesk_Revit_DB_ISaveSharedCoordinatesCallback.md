---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkType.Unload(Autodesk.Revit.DB.ISaveSharedCoordinatesCallback)
source: html/83f4add7-1c0a-ddfa-b8ab-5be6df0f28a2.htm
---
# Autodesk.Revit.DB.RevitLinkType.Unload Method

Unloads the Revit link.

## Syntax (C#)
```csharp
public void Unload(
	ISaveSharedCoordinatesCallback callback
)
```

## Parameters
- **callback** (`Autodesk.Revit.DB.ISaveSharedCoordinatesCallback`) - A callback indicating what to do if Revit encounters
 links which have changes in shared coordinates.
 If Nothing nullptr a null reference ( Nothing in Visual Basic) , Revit will not save any shared coordinates
 changes to the link before unloading.

## Remarks
This function regenerates the document. The document's Undo history will be cleared by this command.
 As a result, this command and others executed before it cannot be undone.
 All transaction phases (e.g. transactions transaction groups and sub-transaction)
 that were explicitly started must be finished prior to calling this method.

## Exceptions
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - The function is not permitted during dynamic update.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RevitLinkType is not a top-level link.
 -or-
 Revit could not save shared coordinates changes to the link
 or one of its nested links.
 -or-
 There is a transaction phase left open (such as a transaction, sub-transaction of transaction group)
 at the time of invoking this method.
 -or-
 The document is read-only. It cannot be modified.
 -or-
 The document is in an edit mode or is in family mode.
 -or-
 Revit cannot link a cloud model to non-cloud model
- **Autodesk.Revit.Exceptions.RevitServerInternalException** - Could be for any of the reasons that failed on service side.
- **Autodesk.Revit.Exceptions.RevitServerUnauthenticatedUserException** - User is not signed in with Autodesk id.
- **Autodesk.Revit.Exceptions.RevitServerUnauthorizedException** - User is not authorized to access the specified cloud model.

