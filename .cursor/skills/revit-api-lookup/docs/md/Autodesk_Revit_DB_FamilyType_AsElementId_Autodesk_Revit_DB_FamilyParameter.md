---
kind: method
id: M:Autodesk.Revit.DB.FamilyType.AsElementId(Autodesk.Revit.DB.FamilyParameter)
source: html/8b31dc65-e397-7e9e-97b8-ed83854c619f.htm
---
# Autodesk.Revit.DB.FamilyType.AsElementId Method

Provides access to the Autodesk::Revit::DB::ElementId^ stored in the given family parameter.

## Syntax (C#)
```csharp
public ElementId AsElementId(
	FamilyParameter familyParameter
)
```

## Parameters
- **familyParameter** (`Autodesk.Revit.DB.FamilyParameter`)

## Returns
The Autodesk::Revit::DB::ElementId^ contained in the parameter.Returns an invalid element id
if the storage type of the input argument is Autodesk::Revit::DB::ElementId^ type or this parameter has no value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"familyParameter"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the input argument-"familyParameter"-is invalid,

