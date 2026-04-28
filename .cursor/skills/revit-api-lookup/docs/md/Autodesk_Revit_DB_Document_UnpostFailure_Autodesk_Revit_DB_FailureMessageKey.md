---
kind: method
id: M:Autodesk.Revit.DB.Document.UnpostFailure(Autodesk.Revit.DB.FailureMessageKey)
zh: 文档、文件
source: html/5bc2e2e4-cdf8-18ad-d910-31f5fe400b74.htm
---
# Autodesk.Revit.DB.Document.UnpostFailure Method

**中文**: 文档、文件

Deletes the posted failure message associated with a given FailureMessageKey.

## Syntax (C#)
```csharp
public void UnpostFailure(
	FailureMessageKey messageKey
)
```

## Parameters
- **messageKey** (`Autodesk.Revit.DB.FailureMessageKey`) - The key of the FailureMessage to be deleted.

## Remarks
If code that previously has posted a failure is executed again or otherwise detects
 that failure conditions do not exist anymore and the failure is not longer relevant,
 it should delete a failure message in order to let transaction to be committed.
 In order to delete the failure, it should invoke this method with a message key
 that was returned when the failure was posted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - messageKey is invalid
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

