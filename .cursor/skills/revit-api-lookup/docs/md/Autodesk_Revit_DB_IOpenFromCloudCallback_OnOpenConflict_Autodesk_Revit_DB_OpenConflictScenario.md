---
kind: method
id: M:Autodesk.Revit.DB.IOpenFromCloudCallback.OnOpenConflict(Autodesk.Revit.DB.OpenConflictScenario)
source: html/21c8169e-9a58-3a6f-9060-e42975f39b16.htm
---
# Autodesk.Revit.DB.IOpenFromCloudCallback.OnOpenConflict Method

A method called when the conflict is happen during the model opening.

## Syntax (C#)
```csharp
OpenConflictResult OnOpenConflict(
	OpenConflictScenario scenario
)
```

## Parameters
- **scenario** (`Autodesk.Revit.DB.OpenConflictScenario`) - The scenario of the conflict.

## Returns
Returns the result to indicate whether to keep the unsynchronized change, or open the latest version or cancel the open action.

