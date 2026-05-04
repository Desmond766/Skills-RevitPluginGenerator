---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewExtrusionForm(System.Boolean,Autodesk.Revit.DB.ReferenceArray,Autodesk.Revit.DB.XYZ)
source: html/4830510f-f19e-f1e2-c1c5-b4eade8f4af2.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewExtrusionForm Method

Create new Form element by Extrude operation, and add it into the Autodesk Revit family document.

## Syntax (C#)
```csharp
public Form NewExtrusionForm(
	bool isSolid,
	ReferenceArray profile,
	XYZ direction
)
```

## Parameters
- **isSolid** (`System.Boolean`) - Indicates if the Form is Solid or Void.
- **profile** (`Autodesk.Revit.DB.ReferenceArray`) - The profile of extrusion. It should consist of only one curve loop.
- **direction** (`Autodesk.Revit.DB.XYZ`) - The direction of extrusion, with its length the length of the extrusion. The direction must be perpendicular to the plane determined by profile. The length of vector must be non-zero.

## Returns
If creation was successful new form is returned.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when creation is attempted in Conceptual Mass, 2D, or other family where extrusions cannot be created.

