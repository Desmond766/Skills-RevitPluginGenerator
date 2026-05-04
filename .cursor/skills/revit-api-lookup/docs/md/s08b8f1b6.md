---
kind: method
id: M:Autodesk.Revit.DB.WorksetTable.RenameWorkset(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.WorksetId,System.String)
source: html/aa6f8625-cf32-cad1-bf9a-eec33abab957.htm
---
# Autodesk.Revit.DB.WorksetTable.RenameWorkset Method

Renames the workset.

## Syntax (C#)
```csharp
public static void RenameWorkset(
	Document aDoc,
	WorksetId worksetId,
	string name
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - The document in which the workset is accessed.
- **worksetId** (`Autodesk.Revit.DB.WorksetId`) - The workset Id.
- **name** (`System.String`) - The workset name.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - aDoc is not a workshared document.
 -or-
 name is an empty string or contains only whitespace.
 -or-
 name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 The given workset name is already in use.
 -or-
 There is no workset in the document with this id.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

