---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinition.GetParameterFormula(Autodesk.Revit.DB.ElementId)
source: html/0a713eab-1202-249e-cfb3-a9f7796be443.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinition.GetParameterFormula Method

Return the parameter's formula, if one is associated with it.

## Syntax (C#)
```csharp
public string GetParameterFormula(
	ElementId paramId
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - Id of a parameter in the definition.

## Returns
The formula, or an empty string if there is no formula for the parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This RebarShapeDefinition does not have a value for the parameter paramId.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

