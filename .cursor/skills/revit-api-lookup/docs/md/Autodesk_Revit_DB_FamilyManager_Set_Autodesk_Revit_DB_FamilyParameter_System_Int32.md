---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.Set(Autodesk.Revit.DB.FamilyParameter,System.Int32)
source: html/f6fab69e-4b4c-002c-ae57-d0120d841ad4.htm
---
# Autodesk.Revit.DB.FamilyManager.Set Method

Set the integer value of a family parameter of the current family type.

## Syntax (C#)
```csharp
public void Set(
	FamilyParameter familyParameter,
	int value
)
```

## Parameters
- **familyParameter** (`Autodesk.Revit.DB.FamilyParameter`) - A family parameter of the current type.
- **value** (`System.Int32`) - The new value for family parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-"familyParameter"-is an invalid family parameter.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the input argument-"familyParameter"-is out of range.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the family parameter is determined by formula,
or the current family type is invalid.

