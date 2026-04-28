---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkType.LoadFrom(Autodesk.Revit.DB.ExternalResourceReference,Autodesk.Revit.DB.WorksetConfiguration)
source: html/f76e2dd3-7448-3aac-baf7-303851f50873.htm
---
# Autodesk.Revit.DB.RevitLinkType.LoadFrom Method

Loads or reloads the Revit link.
 The link will be loaded from the location given in the
 input ExternalResourceReference.

## Syntax (C#)
```csharp
public LinkLoadResult LoadFrom(
	ExternalResourceReference resourceReference,
	WorksetConfiguration config
)
```

## Parameters
- **resourceReference** (`Autodesk.Revit.DB.ExternalResourceReference`) - An external resource reference describing the source of the linked Revit document.
- **config** (`Autodesk.Revit.DB.WorksetConfiguration`) - A WorksetConfiguration object indicating which worksets in the
 link to open. If you want to load the same set of worksets the link previously
 had, leave this argument as Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Returns
An object containing the ElementId of the link
 and an enum value indicating any errors
 which occurred while trying to load.

## Remarks
If the link is currently loaded, Revit must unload
 the link before reloading it. Any changes made in-memory
 to the link's shared coordinates will be discarded. Revit does not try to validate that the input
 represents the "same" document. You can load a
 completely different document, which may invalidate
 references to linked elements. This function regenerates the document. The document's Undo history will be cleared by this command.
 As a result, this command and others executed before it cannot be undone.
 All transaction phases (e.g. transactions transaction groups and sub-transaction)
 that were explicitly started must be finished prior to calling this method.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The server referenced by the ExternalResourceReference does not exist or
 does not implement IExternalResourceServer.
 -or-
 The server referenced by the ExternalResourceReference cannot support Revit links.
 -or-
 The ExternalResourceReference (resourceReference) is not in a format
 that is supported by its server.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileAccessException** - The model cannot be accessed due to lack of access privileges.
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - The function is not permitted during dynamic update.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RevitLinkType is not a top-level link.
 -or-
 The link "this RevitLinkType" is loaded into multiple documents and cannot be reloaded.
 -or-
 The element "this RevitLinkType" is in a closed workset.
 -or-
 There is a transaction phase left open (such as a transaction, sub-transaction of transaction group)
 at the time of invoking this method.
 -or-
 The document is read-only. It cannot be modified.
 -or-
 The document is in an edit mode or is in family mode.
 -or-
 Revit cannot customize worksets for this model.

