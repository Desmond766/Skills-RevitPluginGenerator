---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.RenameParameter(Autodesk.Revit.DB.FamilyParameter,System.String)
source: html/19e7d857-9243-95a0-726c-50b5b7482c3e.htm
---
# Autodesk.Revit.DB.FamilyManager.RenameParameter Method

Rename a family parameter.

## Syntax (C#)
```csharp
public void RenameParameter(
	FamilyParameter familyParameter,
	string name
)
```

## Parameters
- **familyParameter** (`Autodesk.Revit.DB.FamilyParameter`) - The family parameter.
- **name** (`System.String`) - The new name.

## Remarks
This operation is valid only for Family Parameters, and is invalid for Shared Parameters and Built-in Parameters.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"familyParameter" or "name"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-"familyParameter"-is invalid,
or the input name string contains illegal characters, or duplicated with existing parameter name.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when trying to rename a built-in parameter or shared parameter.

