---
kind: method
id: M:Autodesk.Revit.DB.FailureHandlingOptions.SetTransactionFinalizer(Autodesk.Revit.DB.ITransactionFinalizer)
source: html/66f5a5ba-4e72-6401-b29c-6df84b772b4a.htm
---
# Autodesk.Revit.DB.FailureHandlingOptions.SetTransactionFinalizer Method

Sets the callback to be executed after the transaction is completed.

## Syntax (C#)
```csharp
public FailureHandlingOptions SetTransactionFinalizer(
	ITransactionFinalizer finalizer
)
```

## Parameters
- **finalizer** (`Autodesk.Revit.DB.ITransactionFinalizer`) - The callback to be executed after the transaction is completed.

## Returns
This FailureHandlingOptions object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

