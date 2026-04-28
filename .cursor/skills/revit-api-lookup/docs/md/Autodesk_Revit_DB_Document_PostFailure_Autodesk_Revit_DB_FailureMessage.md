---
kind: method
id: M:Autodesk.Revit.DB.Document.PostFailure(Autodesk.Revit.DB.FailureMessage)
zh: 文档、文件
source: html/7184ff0a-f30e-03fb-904f-fb557df6fa37.htm
---
# Autodesk.Revit.DB.Document.PostFailure Method

**中文**: 文档、文件

Posts a failure to be displayed to the user at the end of transaction.

## Syntax (C#)
```csharp
public FailureMessageKey PostFailure(
	FailureMessage failure
)
```

## Parameters
- **failure** (`Autodesk.Revit.DB.FailureMessage`) - The failure to be posted.

## Returns
A unique key that identifies posted failure message in a document. If exactly the same error is posted more than once,
 and not removed between the postings, returned key will be the same every time.

## Remarks
If code inside transaction detects a problem that needs to be communicated to the user,
 it should report these conditions via this method. Failures will be validated and possibly
 resolved at the end of transaction.
 Warnings posted via this method will not be stored in the document after they are resolved.
 A unique key returned by postFailure can be stored for the lifetime of transaction and used to
 remove failure message if it is no longer relevant.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Document must be in state of accepting posted failures and the failures must be appropriate
 for that current state.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

