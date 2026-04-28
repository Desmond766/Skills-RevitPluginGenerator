---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.ReplaceParameter(Autodesk.Revit.DB.FamilyParameter,Autodesk.Revit.DB.ExternalDefinition,Autodesk.Revit.DB.BuiltInParameterGroup,System.Boolean)
source: html/4cb000cc-37ba-11fb-59d2-6790cca209b0.htm
---
# Autodesk.Revit.DB.FamilyManager.ReplaceParameter Method

Replace a family parameter with a shared parameter.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2024 and may be removed in a future version of Revit. Please use the `ReplaceParameter(FamilyParameter, ExternalDefinition, ForgeTypeId, bool)` method instead.")]
public FamilyParameter ReplaceParameter(
	FamilyParameter currentParameter,
	ExternalDefinition familyDefinition,
	BuiltInParameterGroup parameterGroup,
	bool isInstance
)
```

## Parameters
- **currentParameter** (`Autodesk.Revit.DB.FamilyParameter`) - The current family parameter.
- **familyDefinition** (`Autodesk.Revit.DB.ExternalDefinition`) - The definition of the loaded shared parameter.
- **parameterGroup** (`Autodesk.Revit.DB.BuiltInParameterGroup`) - The group to which the new shared parameter belongs.
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

