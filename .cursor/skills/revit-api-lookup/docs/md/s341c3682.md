---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.Set(Autodesk.Revit.DB.FamilyParameter,System.Double)
source: html/7fc40346-6188-66ff-4c00-bd4360e70c6f.htm
---
# Autodesk.Revit.DB.FamilyManager.Set Method

Set the double value of a family parameter of the current family type.

## Syntax (C#)
```csharp
public void Set(
	FamilyParameter familyParameter,
	double value
)
```

## Parameters
- **familyParameter** (`Autodesk.Revit.DB.FamilyParameter`) - A family parameter of the current type.
- **value** (`System.Double`) - The new value for family parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-"familyParameter"-is an invalid family parameter.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the input argument-"familyParameter"-is out of range.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the family parameter is determined by formula,
or the current family type is invalid.

