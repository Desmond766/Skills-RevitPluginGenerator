---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.SetValueString(Autodesk.Revit.DB.FamilyParameter,System.String)
source: html/a7178dc6-34d9-1dc3-d0fa-48454884498b.htm
---
# Autodesk.Revit.DB.FamilyManager.SetValueString Method

Set the string value of a family parameter of the current family type.

## Syntax (C#)
```csharp
public void SetValueString(
	FamilyParameter familyParameter,
	string value
)
```

## Parameters
- **familyParameter** (`Autodesk.Revit.DB.FamilyParameter`) - The family parameter of current type.
- **value** (`System.String`) - The new value string for family parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-"familyParameter" or "value"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-"familyParameter"-is an invalid family parameter.
or the input argument-"value"-is an illegal string.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the input argument-"familyParameter"-is out of range.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the family parameter is determined by formula, or it is not a value type,
or the current family type is invalid.

