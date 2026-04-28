---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewFormByThickenSingleSurface(System.Boolean,Autodesk.Revit.DB.Form,Autodesk.Revit.DB.XYZ)
source: html/4d401155-342d-0a94-b218-3a636882795c.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewFormByThickenSingleSurface Method

Create a new Form element by thickening a single-surface form, and add it into the Autodesk Revit family document.

## Syntax (C#)
```csharp
public Form NewFormByThickenSingleSurface(
	bool isSolid,
	Form singleSurfaceForm,
	XYZ thickenDir
)
```

## Parameters
- **isSolid** (`System.Boolean`) - Indicates if the Form is Solid or Void.
- **singleSurfaceForm** (`Autodesk.Revit.DB.Form`) - The single-surface form element. It can have one top/bottom face or one side face.
- **thickenDir** (`Autodesk.Revit.DB.XYZ`) - The offset of capped solid.

## Returns
This function will modify the input singleSurfaceForm and return the same element.

