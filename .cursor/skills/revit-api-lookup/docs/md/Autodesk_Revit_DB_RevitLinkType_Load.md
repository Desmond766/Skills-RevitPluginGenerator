---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkType.Load
source: html/f46b3b6c-1a9e-a2ab-19d7-367918b3e9f0.htm
---
# Autodesk.Revit.DB.RevitLinkType.Load Method

Loads or reloads the Revit link from its
 currently-stored location. If the link is an
 external resource, Revit will contact the
 IExternalResourceServer to get the latest version
 of the link.

## Syntax (C#)
```csharp
public LinkLoadResult Load()
```

## Returns
An object containing the ElementId of the link
 and an enum value indicating any
 errors which occurred while trying to load.
 LinkLoadResultType.LinkLoaded indicates
 success.

## Remarks
If the link is currently loaded, Revit must unload
 the link before reloading it. Any changes made in-memory
 to the link's shared coordinates will be discarded. This function regenerates the document. The document's Undo history will be cleared by this command.
 As a result, this command and others executed before it cannot be undone.
 All transaction phases (e.g. transactions transaction groups and sub-transaction)
 that were explicitly started must be finished prior to calling this method.

## Exceptions
- **Autodesk.Revit.Exceptions.FileAccessException** - The model cannot be accessed due to lack of access privileges.
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - The element "this RevitLinkType" is in a ducument which is in dynamic update.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The element "this RevitLinkType" is in a family document or a document in in-place edit mode.
 -or-
 The element "this RevitLinkType" is in a document which is in an edit mode or is in family mode.
 -or-
 The element "this RevitLinkType" is in a read-only document.
 -or-
 This RevitLinkType is not a top-level link.
 -or-
 The link "this RevitLinkType" is loaded into multiple documents and cannot be reloaded.
 -or-
 The element "this RevitLinkType" is in a closed workset.
 -or-
 There is a transaction phase left open (such as a transaction, sub-transaction of transaction group)
 at the time of invoking this method.

