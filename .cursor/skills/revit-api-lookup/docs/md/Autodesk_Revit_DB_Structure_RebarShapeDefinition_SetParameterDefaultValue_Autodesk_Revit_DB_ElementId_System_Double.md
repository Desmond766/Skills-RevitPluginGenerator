---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinition.SetParameterDefaultValue(Autodesk.Revit.DB.ElementId,System.Double)
source: html/6aef48cc-9b24-d2cc-3890-dda1598a6157.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinition.SetParameterDefaultValue Method

Change the parameter's value as stored in the definition.

## Syntax (C#)
```csharp
public void SetParameterDefaultValue(
	ElementId paramId,
	double value
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - Id of a parameter in the definition.
- **value** (`System.Double`) - New value for the parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This RebarShapeDefinition does not have a value for the parameter paramId.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

