---
kind: method
id: M:Autodesk.Revit.DB.FabricationServiceButton.IsUnrestrictedCondition(System.Int32)
source: html/e3885c33-fc4c-12ee-6965-ccb9cc16e02f.htm
---
# Autodesk.Revit.DB.FabricationServiceButton.IsUnrestrictedCondition Method

Checks if the condition is unrestricted.

## Syntax (C#)
```csharp
public bool IsUnrestrictedCondition(
	int condition
)
```

## Parameters
- **condition** (`System.Int32`) - The condition index.

## Returns
True if the condition is unrestricted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The index condition is not larger or equal to 0 and less than ConditionCount.

