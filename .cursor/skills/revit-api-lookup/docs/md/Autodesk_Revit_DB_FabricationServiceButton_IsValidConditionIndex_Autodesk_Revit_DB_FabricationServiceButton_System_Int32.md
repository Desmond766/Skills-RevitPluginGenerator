---
kind: method
id: M:Autodesk.Revit.DB.FabricationServiceButton.IsValidConditionIndex(Autodesk.Revit.DB.FabricationServiceButton,System.Int32)
source: html/3f64e765-9531-c198-debe-71dee8b82ee7.htm
---
# Autodesk.Revit.DB.FabricationServiceButton.IsValidConditionIndex Method

Validates if the given condition index is valid or not.

## Syntax (C#)
```csharp
public static bool IsValidConditionIndex(
	FabricationServiceButton button,
	int condition
)
```

## Parameters
- **button** (`Autodesk.Revit.DB.FabricationServiceButton`) - The button to check.
- **condition** (`System.Int32`) - The condition index.

## Returns
True if larger or equal to 0 and less than ConditionCount.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

