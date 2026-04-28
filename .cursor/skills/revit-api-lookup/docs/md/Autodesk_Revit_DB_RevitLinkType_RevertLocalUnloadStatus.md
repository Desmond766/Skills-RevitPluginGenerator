---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkType.RevertLocalUnloadStatus
source: html/4768dc29-83be-99f9-169c-a723202a1b8d.htm
---
# Autodesk.Revit.DB.RevitLinkType.RevertLocalUnloadStatus Method

Restores the workshared load status of a link that has been unloaded only for the current user,
 in a local copy of a workshared model.

## Syntax (C#)
```csharp
public LinkedFileStatus RevertLocalUnloadStatus()
```

## Returns
The link's LinkedFileStatus that has resulted from reverting the local unloaded status.

## Remarks
This function removes the local user's override of the link's workshared load status
 (see UnloadLocally method). That is, if the link is loaded in the central model for
 all worksharing users (and thus has been only unloaded for the local user), then this
 method will perform a full reload of the link for the local user. If the link is
 unloaded in the central model, then this method will simply clear the local user's
 unload override, so that the link will be reloaded in the local user's model,
 if it is ever reloaded in the central model. This function should not be called on a Revit link: in a document which is in an edit mode or is in family mode. in a document which is in dynamic update. in a document which is read only. in a document in which there is transaction phase left open. in a non-workshared file. in a central model of workshared file. which is nested. which are not locally unloaded. If the link is an external resource, Revit will contact the IExternalResourceServer
 to get the latest version of the link.

## Exceptions
- **Autodesk.Revit.Exceptions.FileAccessException** - The model cannot be accessed due to lack of access privileges.
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - The element "this RevitLinkType" is in a ducument which is in dynamic update.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The element "this RevitLinkType" is in a family document or a document in in-place edit mode.
 -or-
 The element "this RevitLinkType" is in a document which is in an edit mode or is in family mode.
 -or-
 The element "this RevitLinkType" is in a read-only document.
 -or-
 This functionality is not available in Revit LT.
 -or-
 The element "this RevitLinkType" is in non-workshared document.
 -or-
 The element "this RevitLinkType" is not in a local model: the model is not workshared or it is central.
 -or-
 This RevitLinkType is not a top-level link.
 -or-
 The link is not locally unloaded.
 -or-
 There is a transaction phase left open (such as a transaction, sub-transaction of transaction group)
 at the time of invoking this method.

