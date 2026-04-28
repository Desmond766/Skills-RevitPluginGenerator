---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewRevolveForms(System.Boolean,Autodesk.Revit.DB.ReferenceArray,Autodesk.Revit.DB.Reference,System.Double,System.Double)
source: html/7ec1ce49-eba0-2d74-0c10-0e97ee9ebca8.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewRevolveForms Method

Create new Form elements by revolve operation, and add them into the Autodesk Revit family document.

## Syntax (C#)
```csharp
public FormArray NewRevolveForms(
	bool isSolid,
	ReferenceArray profile,
	Reference axis,
	double startAngle,
	double endAngle
)
```

## Parameters
- **isSolid** (`System.Boolean`) - Indicates if the Form is Solid or Void.
- **profile** (`Autodesk.Revit.DB.ReferenceArray`) - The profile of the newly created revolution. It should consist of only one curve loop.
The profile must be in the same plane as the axis.
- **axis** (`Autodesk.Revit.DB.Reference`) - The axis of revolution. The axis is a line that must lie in the same plane as the curves in the profile.
- **startAngle** (`System.Double`) - The start angle of Revolution in radians.
- **endAngle** (`System.Double`) - The end angle of Revolution in radians.

## Returns
If creation was successful new forms are returned.

## Remarks
Typically this operation produces only a single form, but some combinations of arguments will create multiple forms from a single profile.

