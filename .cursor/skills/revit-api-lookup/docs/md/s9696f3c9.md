---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.RemoveParameter(Autodesk.Revit.DB.FamilyParameter)
source: html/cb266197-b76e-66db-ea15-2cf14bcb4f85.htm
---
# Autodesk.Revit.DB.FamilyManager.RemoveParameter Method

Remove an existing family parameter from the family.

## Syntax (C#)
```csharp
public void RemoveParameter(
	FamilyParameter familyParameter
)
```

## Parameters
- **familyParameter** (`Autodesk.Revit.DB.FamilyParameter`) - The family parameter.

## Remarks
Only family and shared parameters may be removed, built-in
parameters may not be removed.
If the parameter is used in any formulas, those formulas will be 
automatically removed along with the parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"familyParameter"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-"familyParameter"-is an invalid parameter or a builtIn parameter.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the family parameter deletion failed.

