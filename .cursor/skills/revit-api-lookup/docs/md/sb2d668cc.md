---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerParameterManager.GetIntOverrideValue(Autodesk.Revit.DB.ElementId)
source: html/fa4716f0-ba7b-5d2f-6005-1a6be9e4ddd3.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerParameterManager.GetIntOverrideValue Method

Get the integer value for an overriden parameter.

## Syntax (C#)
```csharp
public int GetIntOverrideValue(
	ElementId paramId
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - The id of the parameter

## Returns
The override value of the parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId is not the id of a parameter in the current document,
 or its value type is not integer.
 -or-
 paramId is not a Rebar Container parameter
 -or-
 paramId has no override
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

