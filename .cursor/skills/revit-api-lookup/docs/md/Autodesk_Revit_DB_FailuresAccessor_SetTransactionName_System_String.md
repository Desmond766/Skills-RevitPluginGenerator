---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.SetTransactionName(System.String)
source: html/89070a80-b41f-f42f-1746-28893aef91f7.htm
---
# Autodesk.Revit.DB.FailuresAccessor.SetTransactionName Method

Changes the name of the transaction for which failures are being processed.

## Syntax (C#)
```csharp
public void SetTransactionName(
	string transactionName
)
```

## Parameters
- **transactionName** (`System.String`) - The name of the transaction to set.

## Remarks
If the transaction will be committed by or after failures processing it can change its name to reflect
 results of processing of the failures. For example, if the original transaction name was "review warnings" and
 some of the warnings were resolved by deleting of the relevant elements, failures processor may
 change the name of the transaction to "delete elements".

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - transactionName is an empty string.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).

