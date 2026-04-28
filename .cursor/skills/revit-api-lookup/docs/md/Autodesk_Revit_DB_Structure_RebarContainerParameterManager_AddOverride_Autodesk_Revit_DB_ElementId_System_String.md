---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerParameterManager.AddOverride(Autodesk.Revit.DB.ElementId,System.String)
source: html/b9cfaccb-15c0-d12c-470a-8ec9f1419979.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerParameterManager.AddOverride Method

Adds an override for the given parameter as its value will be displayed for the Rebar Container element.

## Syntax (C#)
```csharp
public void AddOverride(
	ElementId paramId,
	string value
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - The id of the parameter
- **value** (`System.String`) - The override value of the parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId is not the id of a parameter in the current document,
 or its value type is not sring.
 -or-
 paramId is not a Rebar Container parameter
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

