---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewFormByCap(System.Boolean,Autodesk.Revit.DB.ReferenceArray)
source: html/7a9aac3d-5ee3-c341-bea1-e358a24b1a1b.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewFormByCap Method

Create new Form element by cap operation (to create a single-surface form), and add it into the Autodesk Revit family document.

## Syntax (C#)
```csharp
public Form NewFormByCap(
	bool isSolid,
	ReferenceArray profile
)
```

## Parameters
- **isSolid** (`System.Boolean`) - Indicates if the Form is Solid or Void.
- **profile** (`Autodesk.Revit.DB.ReferenceArray`) - The profile of the newly created cap. It should consist of only one curve loop.

## Returns
If creation was successful new form is returned.

