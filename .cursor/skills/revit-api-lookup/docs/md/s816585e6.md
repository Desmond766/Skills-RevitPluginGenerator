---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.PostFailure(Autodesk.Revit.DB.FailureMessage)
source: html/5d25d459-a1b0-eef4-4766-b00bd1f5ba79.htm
---
# Autodesk.Revit.DB.FailuresAccessor.PostFailure Method

Posts an additional failure message to be processed for the current transaction.

## Syntax (C#)
```csharp
public void PostFailure(
	FailureMessage failure
)
```

## Parameters
- **failure** (`Autodesk.Revit.DB.FailureMessage`) - Failure message to post.

## Remarks
Should be used during failures processing instead of a similar method in a document class.
 Using method of the document class with the same name during failures processing is prohibited.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).

