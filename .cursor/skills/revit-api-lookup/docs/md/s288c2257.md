---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerParameterManager.GetStringOverrideValue(Autodesk.Revit.DB.ElementId)
source: html/bdd0c7ed-421a-fc24-05d0-5cc727c4c013.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerParameterManager.GetStringOverrideValue Method

Get the string value for an overriden parameter.

## Syntax (C#)
```csharp
public string GetStringOverrideValue(
	ElementId paramId
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - The id of the parameter

## Returns
The override value of the parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId is not the id of a parameter in the current document,
 or its value type is not sring.
 -or-
 paramId is not a Rebar Container parameter
 -or-
 paramId has no override
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

