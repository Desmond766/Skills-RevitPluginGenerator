---
kind: method
id: M:Autodesk.Revit.DB.KeyBasedTreeEntryTable.Reload(Autodesk.Revit.DB.KeyBasedTreeEntriesLoadResults)
source: html/a91169d7-4f71-c027-3a24-1d90473e7071.htm
---
# Autodesk.Revit.DB.KeyBasedTreeEntryTable.Reload Method

Reloads KeyBasedTreeEntries from their currently-stored location into this KeyBasedTreeEntryTable.

## Syntax (C#)
```csharp
public ExternalResourceLoadStatus Reload(
	KeyBasedTreeEntriesLoadResults loadResults
)
```

## Parameters
- **loadResults** (`Autodesk.Revit.DB.KeyBasedTreeEntriesLoadResults`) - If provided, Revit will use this object to store any
 errors or warnings that were encountered. Note that if the KeyBasedTreeEntries in the model are
 already up to date, no errors or warnings will be added to this object. This argument may be Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Returns
Returns the outcome of the reload operation.

## Remarks
Revit will try to read KeyBasedTreeEntries from the resource reference stored
 within the KeyBasedTreeEntryTable. If the operation fails, the table will be
 unchanged.

## Exceptions
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document containing this KeyBasedTreeEntryTable is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document containing this KeyBasedTreeEntryTable is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document containing this KeyBasedTreeEntryTable has no open transaction.

