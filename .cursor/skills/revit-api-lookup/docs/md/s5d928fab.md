---
kind: method
id: M:Autodesk.Revit.DB.FabricationServiceButton.GetConditionLowerValue(System.Int32)
source: html/1f081e5c-6343-9046-ee9a-9eeffe1a02ef.htm
---
# Autodesk.Revit.DB.FabricationServiceButton.GetConditionLowerValue Method

Gets the condition lower value (valid if greater or equal) for a given condition index.

## Syntax (C#)
```csharp
public double GetConditionLowerValue(
	int condition
)
```

## Parameters
- **condition** (`System.Int32`) - The condition index.

## Returns
The condition lower value.

## Remarks
A value of -1 indicates an unrestricted value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The index condition is not larger or equal to 0 and less than ConditionCount.

