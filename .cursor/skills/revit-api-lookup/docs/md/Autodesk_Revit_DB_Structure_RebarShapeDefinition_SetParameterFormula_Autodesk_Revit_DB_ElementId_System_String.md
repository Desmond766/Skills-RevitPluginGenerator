---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinition.SetParameterFormula(Autodesk.Revit.DB.ElementId,System.String)
source: html/d1211a0e-cdd6-bfe0-4a08-f58493863d63.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinition.SetParameterFormula Method

Associate a formula with the parameter.

## Syntax (C#)
```csharp
public void SetParameterFormula(
	ElementId paramId,
	string formula
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - Id of a parameter in the definition.
- **formula** (`System.String`) - The formula expressed as a string. The string is exactly what a user would
 type into the Family Types dialog, e.g. "Total Length*3.14159*(Bar Diameter/2)*(Bar Diameter/2)"

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This RebarShapeDefinition does not have a value for the parameter paramId.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

