---
kind: method
id: M:Autodesk.Revit.DB.Transaction.SetFailureHandlingOptions(Autodesk.Revit.DB.FailureHandlingOptions)
zh: 事务
source: html/1e913cca-f75b-8dfb-b172-5a04f3732b85.htm
---
# Autodesk.Revit.DB.Transaction.SetFailureHandlingOptions Method

**中文**: 事务

Sets options for handling failures to be used when the transaction is being committed or rolled back.

## Syntax (C#)
```csharp
public void SetFailureHandlingOptions(
	FailureHandlingOptions options
)
```

## Parameters
- **options** (`Autodesk.Revit.DB.FailureHandlingOptions`) - An instance of FailureHandlingOptions to be applied to the transaction

## Remarks
Options can be set at any time before the transaction is either committed or rolled back.
 See FailureHandlingOptions for details about available options.
 Once committed or rolled back, the transaction object will reset its options to their default values.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

