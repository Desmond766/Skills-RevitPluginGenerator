---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.GetFailureHandlingOptions
source: html/eff2181d-b026-4c4b-b14c-e9c62bbbc01c.htm
---
# Autodesk.Revit.DB.FailuresAccessor.GetFailureHandlingOptions Method

Provides access to the failure handling options for the transaction currently being finished.

## Syntax (C#)
```csharp
public FailureHandlingOptions GetFailureHandlingOptions()
```

## Returns
The failure handling options for transaction currently being finished.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).

