---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.SetDescription(Autodesk.Revit.DB.FamilyParameter,System.String)
source: html/d00fb4a4-6e08-784d-3149-31e9b2d61a12.htm
---
# Autodesk.Revit.DB.FamilyManager.SetDescription Method

Set the description for an existing family parameter. 
The description will be used as tooltip in the Revit UI including in the properties palette.

## Syntax (C#)
```csharp
public void SetDescription(
	FamilyParameter familyParameter,
	string description
)
```

## Parameters
- **familyParameter** (`Autodesk.Revit.DB.FamilyParameter`) - The family parameter.
- **description** (`System.String`) - The description of the family parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"familyParameter"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-"familyParameter"-is an invalid parameter or a builtIn parameter.

