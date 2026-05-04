---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.GetAssociatedFamilyParameter(Autodesk.Revit.DB.Parameter)
source: html/ada33bdc-f484-c4a6-3713-6946dabd5fcf.htm
---
# Autodesk.Revit.DB.FamilyManager.GetAssociatedFamilyParameter Method

Gets the associated family parameter of an element parameter.

## Syntax (C#)
```csharp
public FamilyParameter GetAssociatedFamilyParameter(
	Parameter elementParameter
)
```

## Parameters
- **elementParameter** (`Autodesk.Revit.DB.Parameter`) - The parameter of an element in family.

## Returns
The associated family parameter if there is an association between them, returns Nothing nullptr a null reference ( Nothing in Visual Basic) if not.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"elementParameter"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .

