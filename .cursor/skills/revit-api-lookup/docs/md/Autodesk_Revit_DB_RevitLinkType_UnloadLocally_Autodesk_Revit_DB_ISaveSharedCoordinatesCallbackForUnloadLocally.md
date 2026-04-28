---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkType.UnloadLocally(Autodesk.Revit.DB.ISaveSharedCoordinatesCallbackForUnloadLocally)
source: html/2b12bdb3-1505-960c-7cdb-e41a1295ff60.htm
---
# Autodesk.Revit.DB.RevitLinkType.UnloadLocally Method

Unloads a Revit link for the current user only.

## Syntax (C#)
```csharp
public bool UnloadLocally(
	ISaveSharedCoordinatesCallbackForUnloadLocally callback
)
```

## Parameters
- **callback** (`Autodesk.Revit.DB.ISaveSharedCoordinatesCallbackForUnloadLocally`) - A callback indicating what to do if Revit encounters
 links which have changes in shared coordinates. The saving options for
 unloading locally only could be: save the link, not save the link.
 If Nothing nullptr a null reference ( Nothing in Visual Basic) , Revit will not save any shared coordinates
 changes to the link before unloading.

## Returns
Returns true if the attempt to unload the link locally was successful.

## Remarks
This function unloads the Revit link for the current user,
 instead of all users, in the workshared files. If you want to unload the Revit link for all users, please use Unload(ISaveSharedCoordinatesCallback) . This function should not be called on a Revit link: in a document which is in an edit mode or is in family mode. in a document which is in dynamic update. in a document which is read only. in a document in which there is transaction phase left open. in a non-workshared file. in a central model of workshared file. which is nested. which is unloaded locally already.

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
 The link "this RevitLinkType" is locally unloaded for current user already.
 -or-
 There is a transaction phase left open (such as a transaction, sub-transaction of transaction group)
 at the time of invoking this method.

