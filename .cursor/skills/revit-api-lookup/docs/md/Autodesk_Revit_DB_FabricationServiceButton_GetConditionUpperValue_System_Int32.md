---
kind: method
id: M:Autodesk.Revit.DB.FabricationServiceButton.GetConditionUpperValue(System.Int32)
source: html/2b55ee19-8ec2-963f-d0cd-53629dc9b80e.htm
---
# Autodesk.Revit.DB.FabricationServiceButton.GetConditionUpperValue Method

Gets the condition upper value (valid if less) for a given condition index.

## Syntax (C#)
```csharp
public double GetConditionUpperValue(
	int condition
)
```

## Parameters
- **condition** (`System.Int32`) - The condition index.

## Returns
The condition upper value.

## Remarks
A value of -1 indicates an unrestricted value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The index condition is not larger or equal to 0 and less than ConditionCount.

