---
kind: method
id: M:Autodesk.Revit.DB.FamilyType.AsInteger(Autodesk.Revit.DB.FamilyParameter)
source: html/cd9fd09d-adfa-5037-8b77-510e9dcdcc0f.htm
---
# Autodesk.Revit.DB.FamilyType.AsInteger Method

Provides access to the integer number of the given family parameter.

## Syntax (C#)
```csharp
public Nullable<int> AsInteger(
	FamilyParameter familyParameter
)
```

## Parameters
- **familyParameter** (`Autodesk.Revit.DB.FamilyParameter`)

## Returns
The integer value contained in the parameter. Returns Nothing nullptr a null reference ( Nothing in Visual Basic) 
if the storage type of the input argument is not integer type or this parameter has no value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"familyParameter"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the input argument-"familyParameter"-is invalid,

