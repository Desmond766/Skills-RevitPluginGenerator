---
kind: method
id: M:Autodesk.Revit.DB.FamilyType.AsValueString(Autodesk.Revit.DB.FamilyParameter)
source: html/3391d3ca-829e-3952-1aa6-324010621026.htm
---
# Autodesk.Revit.DB.FamilyType.AsValueString Method

Provides access to value as a string with unit in the given family parameter.

## Syntax (C#)
```csharp
public string AsValueString(
	FamilyParameter familyParameter
)
```

## Parameters
- **familyParameter** (`Autodesk.Revit.DB.FamilyParameter`)

## Returns
The string that represents the parameter value with unit.

## Remarks
The method only applies to parameters of value types. If the parameter has no value or does not contain a numeric value,
the method returns Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"familyParameter"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the input argument-"familyParameter"-is invalid.

