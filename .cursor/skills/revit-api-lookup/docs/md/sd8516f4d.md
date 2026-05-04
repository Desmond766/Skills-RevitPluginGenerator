---
kind: method
id: M:Autodesk.Revit.DB.FabricationServiceButton.GetConditionName(System.Int32)
source: html/f278b65d-03ff-a16b-356f-4dd1b1aaf8aa.htm
---
# Autodesk.Revit.DB.FabricationServiceButton.GetConditionName Method

Gets the name of the specified condition on the fabrication service button.

## Syntax (C#)
```csharp
public string GetConditionName(
	int condition
)
```

## Parameters
- **condition** (`System.Int32`) - The condition index.

## Returns
The name of the specified condition on the fabrication service button.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The index condition is not larger or equal to 0 and less than ConditionCount.

