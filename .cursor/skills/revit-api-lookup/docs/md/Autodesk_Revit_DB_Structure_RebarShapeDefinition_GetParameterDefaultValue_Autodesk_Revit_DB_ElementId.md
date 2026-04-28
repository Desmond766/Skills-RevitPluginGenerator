---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinition.GetParameterDefaultValue(Autodesk.Revit.DB.ElementId)
source: html/148ee5cc-0ca8-96ca-6b73-91fe86437660.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinition.GetParameterDefaultValue Method

Return the parameter's default value as stored in the definition.

## Syntax (C#)
```csharp
public double GetParameterDefaultValue(
	ElementId paramId
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - Id of a parameter in the definition.

## Returns
The parameter value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This RebarShapeDefinition does not have a value for the parameter paramId.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

