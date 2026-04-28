---
kind: method
id: M:Autodesk.Revit.DB.EditScope.Cancel
source: html/7d36a76e-dc13-c17e-b999-891c9c6fe4df.htm
---
# Autodesk.Revit.DB.EditScope.Cancel Method

Cancels the edit scope.

## Syntax (C#)
```csharp
public void Cancel()
```

## Remarks
All the changes made after starting the EditScope will be rolled back.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - EditScope is not active. EditScope can only be committed or cancelled when it is active.
 -or-
 EditScope cannot be closed, for there is a transaction or transaction group still open in the document.

