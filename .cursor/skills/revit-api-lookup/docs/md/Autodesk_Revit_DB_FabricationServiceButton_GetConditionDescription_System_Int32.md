---
kind: method
id: M:Autodesk.Revit.DB.FabricationServiceButton.GetConditionDescription(System.Int32)
source: html/2a084dae-2b93-2631-0f6a-ac3cd38268df.htm
---
# Autodesk.Revit.DB.FabricationServiceButton.GetConditionDescription Method

Gets the description for the condition size range.

## Syntax (C#)
```csharp
public string GetConditionDescription(
	int condition
)
```

## Parameters
- **condition** (`System.Int32`) - The index of the condition in the service button.

## Returns
A user-defined string that describes the condition range, as defined in the fabrication configuration.
 For example, this may describe the size of the range or describe the type of fitting.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The index condition is not larger or equal to 0 and less than ConditionCount.

