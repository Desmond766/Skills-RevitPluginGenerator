---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.SetFormula(Autodesk.Revit.DB.FamilyParameter,System.String)
source: html/cdc3156c-0334-0bba-70af-1df78fb18b50.htm
---
# Autodesk.Revit.DB.FamilyManager.SetFormula Method

Set the formula of a family parameter.

## Syntax (C#)
```csharp
public void SetFormula(
	FamilyParameter familyParameter,
	string formula
)
```

## Parameters
- **familyParameter** (`Autodesk.Revit.DB.FamilyParameter`) - The family parameter.
- **formula** (`System.String`) - The formula string, input Nothing nullptr a null reference ( Nothing in Visual Basic) to clean the formula of the parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"familyParameter"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when there is no valid family type,
or the parameter cannot be assigned a formula,
or the operation make a circular chain of references among the formulas.

