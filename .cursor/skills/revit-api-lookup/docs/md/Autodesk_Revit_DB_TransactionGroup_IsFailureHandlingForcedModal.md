---
kind: property
id: P:Autodesk.Revit.DB.TransactionGroup.IsFailureHandlingForcedModal
source: html/2365a964-dd55-0727-9f5d-f54df40da118.htm
---
# Autodesk.Revit.DB.TransactionGroup.IsFailureHandlingForcedModal Property

Forces all transactions finished inside this group to use modal failure handling
 regardless of what failure handling options are set for those transactions.

## Syntax (C#)
```csharp
public bool IsFailureHandlingForcedModal { get; set; }
```

## Remarks
This property is ignored during events, when failure handling is always modal.

