---
kind: method
id: M:Autodesk.Revit.DB.EditScope.Commit(Autodesk.Revit.DB.IFailuresPreprocessor)
source: html/c82741e1-58b8-ee1f-7deb-1764af63f37a.htm
---
# Autodesk.Revit.DB.EditScope.Commit Method

Finishes the edit scope.

## Syntax (C#)
```csharp
public void Commit(
	IFailuresPreprocessor failurePreprocessor
)
```

## Parameters
- **failurePreprocessor** (`Autodesk.Revit.DB.IFailuresPreprocessor`) - Callback to be invoked in the beginning of failure processing.

## Remarks
All the changes made after starting the EditScope will be committed. Changes will be merged into one transaction.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - EditScope is not active. EditScope can only be committed or cancelled when it is active.
 -or-
 EditScope cannot be closed, for there is a transaction or transaction group still open in the document.

