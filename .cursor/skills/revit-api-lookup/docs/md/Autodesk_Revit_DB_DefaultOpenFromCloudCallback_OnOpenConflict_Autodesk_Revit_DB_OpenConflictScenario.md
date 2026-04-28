---
kind: method
id: M:Autodesk.Revit.DB.DefaultOpenFromCloudCallback.OnOpenConflict(Autodesk.Revit.DB.OpenConflictScenario)
source: html/bd2cf2db-4e63-2cf9-3b7e-88bdc00d78ff.htm
---
# Autodesk.Revit.DB.DefaultOpenFromCloudCallback.OnOpenConflict Method

A method called when the conflict is happen during the model opening.

## Syntax (C#)
```csharp
public virtual OpenConflictResult OnOpenConflict(
	OpenConflictScenario scenario
)
```

## Parameters
- **scenario** (`Autodesk.Revit.DB.OpenConflictScenario`) - The scenario of the conflict.

## Returns
Returns the result to indicate whether to keep the unsynchronized change, or open the latest version or cancel the open action.

