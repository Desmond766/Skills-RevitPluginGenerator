---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.Set(Autodesk.Revit.DB.FamilyParameter,System.String)
source: html/428551ba-9037-2e23-7f18-8747624d0ff2.htm
---
# Autodesk.Revit.DB.FamilyManager.Set Method

Set the string value of a family parameter of the current family type.

## Syntax (C#)
```csharp
public void Set(
	FamilyParameter familyParameter,
	string value
)
```

## Parameters
- **familyParameter** (`Autodesk.Revit.DB.FamilyParameter`) - A family parameter of the current type.
- **value** (`System.String`) - The new value for family parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"familyParameter"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-"familyParameter"-is an invalid family parameter.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the input argument-"familyParameter"-is out of range.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the family parameter is determined by formula,
or the current family type is invalid.

