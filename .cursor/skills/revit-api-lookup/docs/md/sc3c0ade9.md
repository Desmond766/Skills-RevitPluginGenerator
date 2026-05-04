---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.ReplaceParameter(Autodesk.Revit.DB.FamilyParameter,System.String,Autodesk.Revit.DB.BuiltInParameterGroup,System.Boolean)
source: html/5eb146f4-968c-332e-b017-b9dd7b27274f.htm
---
# Autodesk.Revit.DB.FamilyManager.ReplaceParameter Method

Replace a shared family parameter with a new non-shared family parameter.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2024 and may be removed in a future version of Revit. Please use the `ReplaceParameter(FamilyParameter, ExternalDefinition, ForgeTypeId, bool)` method instead.")]
public FamilyParameter ReplaceParameter(
	FamilyParameter currentParameter,
	string parameterName,
	BuiltInParameterGroup parameterGroup,
	bool isInstance
)
```

## Parameters
- **currentParameter** (`Autodesk.Revit.DB.FamilyParameter`) - The current family parameter.
- **parameterName** (`System.String`) - The name of the new family parameter.
- **parameterGroup** (`Autodesk.Revit.DB.BuiltInParameterGroup`) - The group to which the new family parameter belongs.
- **isInstance** (`System.Boolean`) - Indicates if the new parameter is instance or type.

## Returns
If replacement was successful the new family parameter is returned, 
otherwise an exception with failure information will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"currentParameter" or "parameterName"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-"currentParameter"-is invalid,
or the input parameter group cannot be assigned to the new parameter,
or the input name string contains illegal characters, or duplicated with existing parameter name.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when trying to replace a built-in parameter or family parameter.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when replacement failed, because the replacement would cause a formula error.
Or trying to replace with an instance parameter of image type.

