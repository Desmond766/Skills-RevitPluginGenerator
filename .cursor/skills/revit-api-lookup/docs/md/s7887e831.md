---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerParameterManager.AddOverride(Autodesk.Revit.DB.ElementId,System.Double)
source: html/37cdef48-c22a-633f-7047-33f9d170f641.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerParameterManager.AddOverride Method

Adds an override for the given parameter as its value will be displayed for the Rebar Container element.

## Syntax (C#)
```csharp
public void AddOverride(
	ElementId paramId,
	double value
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - The id of the parameter
- **value** (`System.Double`) - The override value of the parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId is not the id of a parameter in the current document,
 or its value type is not double.
 -or-
 paramId is not a Rebar Container parameter
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

