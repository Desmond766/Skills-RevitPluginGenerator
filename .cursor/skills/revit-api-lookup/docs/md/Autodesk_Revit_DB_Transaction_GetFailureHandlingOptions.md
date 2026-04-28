---
kind: method
id: M:Autodesk.Revit.DB.Transaction.GetFailureHandlingOptions
zh: 事务
source: html/f306f808-a753-1585-18ef-57d65e76fad4.htm
---
# Autodesk.Revit.DB.Transaction.GetFailureHandlingOptions Method

**中文**: 事务

Returns the current failure handling options.

## Syntax (C#)
```csharp
public FailureHandlingOptions GetFailureHandlingOptions()
```

## Returns
An instance of FailureHandlingOptions

## Remarks
The returned instance is a copy of the options.
 If changes are made to the options, the new version can be set back to
 the transaction by calling the SetFailureHandlingOptions(FailureHandlingOptions) method.

