---
kind: method
id: M:Autodesk.Revit.DB.KeyBasedTreeEntryTable.LoadFrom(Autodesk.Revit.DB.ExternalResourceReference,Autodesk.Revit.DB.KeyBasedTreeEntriesLoadResults)
source: html/51da265d-a879-61dd-3b59-b919bf2645f4.htm
---
# Autodesk.Revit.DB.KeyBasedTreeEntryTable.LoadFrom Method

Loads KeyBasedTreeEntries from the specified external resource into this KeyBasedTreeEntryTable.

## Syntax (C#)
```csharp
public ExternalResourceLoadStatus LoadFrom(
	ExternalResourceReference desiredResourceReference,
	KeyBasedTreeEntriesLoadResults loadResults
)
```

## Parameters
- **desiredResourceReference** (`Autodesk.Revit.DB.ExternalResourceReference`) - An external resource reference describing the source of the desired KeyBasedTreeEntry data.
- **loadResults** (`Autodesk.Revit.DB.KeyBasedTreeEntriesLoadResults`) - If provided, Revit will use this object to store any
 errors or warnings that were encountered. This argument may be Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Returns
Returns whether the operation succeeded or failed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The server referenced by the ExternalResourceReference does not exist or
 does not implement IExternalResourceServer.
 -or-
 The server referenced by the ExternalResourceReference cannot support the ExternalResourceReferenceType of this KeyBasedTreeEntryTable.
 -or-
 The ExternalResourceReference (desiredResourceReference) is not in a format
 that is supported by its server.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document containing this KeyBasedTreeEntryTable is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document containing this KeyBasedTreeEntryTable is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document containing this KeyBasedTreeEntryTable has no open transaction.

