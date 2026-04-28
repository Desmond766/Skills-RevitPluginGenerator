---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.ReplaceParameter(Autodesk.Revit.DB.FamilyParameter,Autodesk.Revit.DB.ExternalDefinition,Autodesk.Revit.DB.ForgeTypeId,System.Boolean)
source: html/9ddbd75b-887d-397a-14aa-3e4052a2a2eb.htm
---
# Autodesk.Revit.DB.FamilyManager.ReplaceParameter Method

Replace a family parameter with a shared parameter.

## Syntax (C#)
```csharp
public FamilyParameter ReplaceParameter(
	FamilyParameter currentParameter,
	ExternalDefinition familyDefinition,
	ForgeTypeId groupTypeId,
	bool isInstance
)
```

## Parameters
- **currentParameter** (`Autodesk.Revit.DB.FamilyParameter`) - The current family parameter.
- **familyDefinition** (`Autodesk.Revit.DB.ExternalDefinition`) - The definition of the loaded shared parameter.
- **groupTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - The identifier of the group to which the new shared parameter belongs.
- **isInstance** (`System.Boolean`) - Indicates if the new parameter is instance or type.

## Returns
If replacement was successful the new shared parameter is returned, 
otherwise an exception with failure information will be thrown.

## Remarks
This operation is invalid for Built-in Parameters. 
The formulas and labels which in reference to this parameter will be updated to the new parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"familyParameter" or "name"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-"familyParameter"-is invalid,
or the input parameter group cannot be assigned to the new parameter,
or the input name string contains illegal characters, or duplicated with existing parameter name.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when trying to replace a built-in parameter.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when replacement failed, because the replacement would cause a formula error.
Or trying to replace with an instance parameter of image type.

