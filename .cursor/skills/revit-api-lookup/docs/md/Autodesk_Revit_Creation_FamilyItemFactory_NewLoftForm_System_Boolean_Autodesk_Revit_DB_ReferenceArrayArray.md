---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewLoftForm(System.Boolean,Autodesk.Revit.DB.ReferenceArrayArray)
source: html/74116ec1-986c-251b-2ce8-4a64faa47f7d.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewLoftForm Method

Create new Form element by Loft operation, and add it into the Autodesk Revit family document.

## Syntax (C#)
```csharp
public Form NewLoftForm(
	bool isSolid,
	ReferenceArrayArray profiles
)
```

## Parameters
- **isSolid** (`System.Boolean`) - Indicates if the Form is Solid or Void.
- **profiles** (`Autodesk.Revit.DB.ReferenceArrayArray`) - The profile set of the newly created loft. Each profile should consist of only one curve loop.

## Returns
If creation was successful form is are returned.

