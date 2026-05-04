---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerParameterManager.GetDoubleOverrideValue(Autodesk.Revit.DB.ElementId)
source: html/269b5ffa-a173-d34a-20ce-b3d98ca793f6.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerParameterManager.GetDoubleOverrideValue Method

Get the double value for an overriden parameter.

## Syntax (C#)
```csharp
public double GetDoubleOverrideValue(
	ElementId paramId
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - The id of the parameter

## Returns
The override value of the parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId is not the id of a parameter in the current document,
 or its value type is not double.
 -or-
 paramId is not a Rebar Container parameter
 -or-
 paramId has no override
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

