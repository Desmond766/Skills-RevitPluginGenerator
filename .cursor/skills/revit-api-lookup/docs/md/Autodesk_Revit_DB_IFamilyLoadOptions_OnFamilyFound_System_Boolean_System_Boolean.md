---
kind: method
id: M:Autodesk.Revit.DB.IFamilyLoadOptions.OnFamilyFound(System.Boolean,System.Boolean@)
source: html/515baa3b-3a13-bb28-6c94-a84651b4dbfb.htm
---
# Autodesk.Revit.DB.IFamilyLoadOptions.OnFamilyFound Method

A method called when the family was found in the target document.

## Syntax (C#)
```csharp
bool OnFamilyFound(
	bool familyInUse,
	out bool overwriteParameterValues
)
```

## Parameters
- **familyInUse** (`System.Boolean`) - Indicates if one or more instances of the family is placed in the project.
- **overwriteParameterValues** (`System.Boolean %`) - This determines whether or not to overwrite the parameter
 values of existing types. The default value is false.

## Returns
Return true to continue loading the family, false to cancel.

## Remarks
Triggered only when the family is both loaded and changed.

