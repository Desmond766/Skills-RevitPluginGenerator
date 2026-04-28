---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewSweptBlendForm(System.Boolean,Autodesk.Revit.DB.ReferenceArray,Autodesk.Revit.DB.ReferenceArrayArray)
source: html/2a5b308c-ff6a-d29a-2810-ac1d843c4945.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewSweptBlendForm Method

Create new Form element by swept blend operation, and add it into the Autodesk Revit family document.

## Syntax (C#)
```csharp
public Form NewSweptBlendForm(
	bool isSolid,
	ReferenceArray path,
	ReferenceArrayArray profiles
)
```

## Parameters
- **isSolid** (`System.Boolean`) - Indicates if the Form is Solid or Void.
- **path** (`Autodesk.Revit.DB.ReferenceArray`) - The path of the swept blend. The path should be 2D, where all input curves lie in one plane. If there's more than one profile, the path should be a single curve. 
It's required to reference existing geometry.
- **profiles** (`Autodesk.Revit.DB.ReferenceArrayArray`) - The profile set of the newly created swept blend. Each profile should consist of only one curve loop.
Each profile must be in a plane that intersects with the path and is perpendicular to the path at the point of intersection.

## Returns
If creation was successful new form is returned.

