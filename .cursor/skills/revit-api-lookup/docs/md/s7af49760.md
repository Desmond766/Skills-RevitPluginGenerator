---
kind: method
id: M:Autodesk.Revit.DB.ViewSection.CreateCallout(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
zh: 剖面视图、剖面
source: html/272ce735-271e-6ae3-8b36-c31207c99e56.htm
---
# Autodesk.Revit.DB.ViewSection.CreateCallout Method

**中文**: 剖面视图、剖面

Creates a new callout view.

## Syntax (C#)
```csharp
public static View CreateCallout(
	Document document,
	ElementId parentViewId,
	ElementId viewFamilyTypeId,
	XYZ point1,
	XYZ point2
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the new callout will be added.
- **parentViewId** (`Autodesk.Revit.DB.ElementId`) - The view in which the callout appears.
 Callouts can be created in FloorPlan, CeilingPlan, StructuralPlan, Section, Elevation,
 and Detail views.
- **viewFamilyTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the ViewFamilyType which will be used by the new callout ViewSection.
 Detail ViewFamilyTypes can be used in all parent views except for CeilingPlan and Drafting views.
 FloorPlan, CeilingPlan, StructuralPlan, Section, and Elevation ViewFamilyTypes may be
 be used in parent views that also use a type with the same ViewFamily enum value.
 For example, in StructuralPlan parent views both StructuralPlan and Detail ViewFamilyTypes are allowed.
- **point1** (`Autodesk.Revit.DB.XYZ`) - Determines the extents of the callout symbol in the parent view.
- **point2** (`Autodesk.Revit.DB.XYZ`) - Determine the extents of the callout symbol in the parent view.

## Returns
The new callout view. The view will be either a ViewSection, ViewPlan or ViewDetail.

## Remarks
The extents of new callout are determined by using the two argument points as the
 opposing corners of a rectangle which is aligned to the directions of the parent view.
 The callout's near and far cut planes will match those of the parent view.
 The new view will receive a unique name.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Non-reference callouts are not allowed in parent views of this type.
 -or-
 Callouts of the supplied ViewFamilyType are not allowed in the parent view.
 -or-
 point1 and point2 do not differ when projected onto a plane perpendicular to the view direction.
 -or-
 Callout view creation is not allowed in this family.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

