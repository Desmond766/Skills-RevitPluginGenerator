---
kind: method
id: M:Autodesk.Revit.DB.IFamilyLoadOptions.OnSharedFamilyFound(Autodesk.Revit.DB.Family,System.Boolean,Autodesk.Revit.DB.FamilySource@,System.Boolean@)
source: html/7bb3a582-a7c0-1f3d-ebe3-33a1bfa443fc.htm
---
# Autodesk.Revit.DB.IFamilyLoadOptions.OnSharedFamilyFound Method

A method called when the shared family was found in the target document.

## Syntax (C#)
```csharp
bool OnSharedFamilyFound(
	Family sharedFamily,
	bool familyInUse,
	out FamilySource source,
	out bool overwriteParameterValues
)
```

## Parameters
- **sharedFamily** (`Autodesk.Revit.DB.Family`) - The shared family in the current family document.
- **familyInUse** (`System.Boolean`) - Indicates if one or more instances of the family is placed in the project.
- **source** (`Autodesk.Revit.DB.FamilySource %`) - This indicates if the family will load from
 the project or the current family.
- **overwriteParameterValues** (`System.Boolean %`) - This indicates whether or not to overwrite the parameter
 values of existing types.

## Returns
Return true to continue loading the family, false to cancel.

## Remarks
Triggered only when the family is both loaded and changed.

