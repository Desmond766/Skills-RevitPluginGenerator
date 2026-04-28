---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerParameterManager.AddOverride(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/162cbdc9-f640-ca81-fb77-f7456993951f.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerParameterManager.AddOverride Method

Adds an override for the given parameter as its value will be displayed for the Rebar Container element.

## Syntax (C#)
```csharp
public void AddOverride(
	ElementId paramId,
	ElementId value
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - The id of the parameter
- **value** (`Autodesk.Revit.DB.ElementId`) - The override value of the parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId is not the id of a parameter in the current document,
 or its value type is not ElementId.
 -or-
 paramId is not a Rebar Container parameter
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

