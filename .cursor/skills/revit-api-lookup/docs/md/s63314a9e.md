---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.AssociateElementParameterToFamilyParameter(Autodesk.Revit.DB.Parameter,Autodesk.Revit.DB.FamilyParameter)
source: html/a047ea58-0351-b419-d856-85ed23734ee8.htm
---
# Autodesk.Revit.DB.FamilyManager.AssociateElementParameterToFamilyParameter Method

Associates or disassociates the element parameter to an existing family parameter.

## Syntax (C#)
```csharp
public void AssociateElementParameterToFamilyParameter(
	Parameter elementParameter,
	FamilyParameter familyParameter
)
```

## Parameters
- **elementParameter** (`Autodesk.Revit.DB.Parameter`) - The parameter of an element in family.
- **familyParameter** (`Autodesk.Revit.DB.FamilyParameter`) - The existing family parameter. If the input to this argument is Nothing nullptr a null reference ( Nothing in Visual Basic) ,
it will disassociate the element parameter from any family parameters.

## Remarks
The parameter types of these two input parameter should be same, if not an 
exception with failure information will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"elementParameter"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-"elementParameter" or "familyParameter"-is an invalid parameter,
or the input argument-"elementParameter"-cannot be associated.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the family parameter binding failed.

