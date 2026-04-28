---
kind: method
id: M:Autodesk.Revit.DB.FamilyType.AsDouble(Autodesk.Revit.DB.FamilyParameter)
source: html/181e5f71-307b-4962-1203-38deaaacf75b.htm
---
# Autodesk.Revit.DB.FamilyType.AsDouble Method

Provides access to the double precision number of the given family parameter.

## Syntax (C#)
```csharp
public Nullable<double> AsDouble(
	FamilyParameter familyParameter
)
```

## Parameters
- **familyParameter** (`Autodesk.Revit.DB.FamilyParameter`)

## Returns
The double value contained in the parameter. Returns Nothing nullptr a null reference ( Nothing in Visual Basic) 
if the storage type of the input argument is not double type or this parameter has no value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"familyParameter"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the input argument-"familyParameter"-is invalid,

