---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerParameterManager.GetElementIdOverrideValue(Autodesk.Revit.DB.ElementId)
source: html/5c9dca6a-77dd-9631-47f8-b0f02c8ca905.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerParameterManager.GetElementIdOverrideValue Method

Get the ElementId value for an overriden parameter.

## Syntax (C#)
```csharp
public ElementId GetElementIdOverrideValue(
	ElementId paramId
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - The id of the parameter

## Returns
The override value of the parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId is not the id of a parameter in the current document,
 or its value type is not ElementId.
 -or-
 paramId is not a Rebar Container parameter
 -or-
 paramId has no override
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

