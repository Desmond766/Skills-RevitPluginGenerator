---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkType.LoadFrom(Autodesk.Revit.DB.ModelPath,Autodesk.Revit.DB.WorksetConfiguration)
source: html/bdb3a91e-9a0a-e68d-51da-c460535f5fd2.htm
---
# Autodesk.Revit.DB.RevitLinkType.LoadFrom Method

Loads or reloads the Revit link from disk or cloud.
 The link will be loaded from the input path.

## Syntax (C#)
```csharp
public LinkLoadResult LoadFrom(
	ModelPath path,
	WorksetConfiguration config
)
```

## Parameters
- **path** (`Autodesk.Revit.DB.ModelPath`) - A ModelPath indicating where to load the link from.
 This may be a path of local disk, Revit Server or Cloud.
 This must be an absolute path for local path.
- **config** (`Autodesk.Revit.DB.WorksetConfiguration`) - A WorksetConfiguration object indicating which worksets in the
 link to open. If you want to load the same set of worksets the link previously
 had, leave this argument as Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Returns
An object containing the ElementId of the link
 and an enum value indicating any errors
 which occurred while trying to load.

## Remarks
The input path must be absolute. Revit will store
 an absolute or relative path internally, according
 to the link's settings. Revit Server paths or cloud paths are acceptable. If the link is currently loaded, Revit must unload
 the link before reloading it. Any changes made in-memory
 to the link's shared coordinates will be discarded. Revit does not try to validate that the input path
 represents the "same" document. You can load a
 completely different document, which may invalidate
 references to linked elements. This function regenerates the document. The document's Undo history will be cleared by this command.
 As a result, this command and others executed before it cannot be undone.
 All transaction phases (e.g. transactions transaction groups and sub-transaction)
 that were explicitly started must be finished prior to calling this method.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input path "path" does not represent a Revit model.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileAccessException** - The model cannot be accessed due to lack of access privileges.
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - The function is not permitted during dynamic update.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RevitLinkType is not a top-level link.
 -or-
 The link "this RevitLinkType" is loaded into multiple documents and cannot be reloaded.
 -or-
 The element "this RevitLinkType" is in a closed workset.
 -or-
 The model is not allowed to access.
 -or-
 There is a transaction phase left open (such as a transaction, sub-transaction of transaction group)
 at the time of invoking this method.
 -or-
 The document is read-only. It cannot be modified.
 -or-
 The document is in an edit mode or is in family mode.
 -or-
 Revit cannot customize worksets for this model.
 -or-
 Revit cannot link a cloud model to non-cloud model.
- **Autodesk.Revit.Exceptions.RevitServerInternalException** - Could be for any of the reasons that failed on service side.
- **Autodesk.Revit.Exceptions.RevitServerUnauthenticatedUserException** - User is not signed in with Autodesk id.
- **Autodesk.Revit.Exceptions.RevitServerUnauthorizedException** - User is not authorized to access the specified cloud model.

