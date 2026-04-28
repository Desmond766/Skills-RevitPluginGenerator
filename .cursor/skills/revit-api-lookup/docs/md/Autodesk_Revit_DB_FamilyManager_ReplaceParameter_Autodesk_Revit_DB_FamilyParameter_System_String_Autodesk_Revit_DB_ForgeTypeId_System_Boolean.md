---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.ReplaceParameter(Autodesk.Revit.DB.FamilyParameter,System.String,Autodesk.Revit.DB.ForgeTypeId,System.Boolean)
source: html/b276c350-b06f-69fe-c9e2-a9d938c3e973.htm
---
# Autodesk.Revit.DB.FamilyManager.ReplaceParameter Method

Replace a shared family parameter with a new non-shared family parameter.

## Syntax (C#)
```csharp
public FamilyParameter ReplaceParameter(
	FamilyParameter currentParameter,
	string parameterName,
	ForgeTypeId groupTypeId,
	bool isInstance
)
```

## Parameters
- **currentParameter** (`Autodesk.Revit.DB.FamilyParameter`) - The current family parameter.
- **parameterName** (`System.String`) - The name of the new family parameter.
- **groupTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - The identifier of the group to which the new family parameter belongs.
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

