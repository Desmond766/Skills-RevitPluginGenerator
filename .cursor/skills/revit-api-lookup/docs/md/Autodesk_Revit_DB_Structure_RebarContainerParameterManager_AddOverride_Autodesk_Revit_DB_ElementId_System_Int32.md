---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerParameterManager.AddOverride(Autodesk.Revit.DB.ElementId,System.Int32)
source: html/1a855734-c230-30ee-8d74-33617eb7bc3f.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerParameterManager.AddOverride Method

Adds an override for the given parameter as its value will be displayed for the Rebar Container element.

## Syntax (C#)
```csharp
public void AddOverride(
	ElementId paramId,
	int value
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - The id of the parameter
- **value** (`System.Int32`) - The override value of the parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId is not the id of a parameter in the current document,
 or its value type is not integer.
 -or-
 paramId is not a Rebar Container parameter
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

