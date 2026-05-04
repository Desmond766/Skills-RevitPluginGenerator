---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.Set(Autodesk.Revit.DB.FamilyParameter,Autodesk.Revit.DB.ElementId)
source: html/5004314a-c77f-e469-1e03-395f5e17de5a.htm
---
# Autodesk.Revit.DB.FamilyManager.Set Method

Set the ElementId value of a family parameter of the current family type.

## Syntax (C#)
```csharp
public void Set(
	FamilyParameter familyParameter,
	ElementId value
)
```

## Parameters
- **familyParameter** (`Autodesk.Revit.DB.FamilyParameter`) - A family parameter of the current type.
- **value** (`Autodesk.Revit.DB.ElementId`) - The new value for family parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the storage type of family parameter is not ElementId --or-- The input ElementId does not represent either a valid element in the document or InvalidElementId.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the input ElementId is not valid as a value for this FamilyParameter.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the family parameter is determined by formula,
or the current family type is invalid.

