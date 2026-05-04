---
kind: method
id: M:Autodesk.Revit.DB.ViewSection.CreateReferenceCallout(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
zh: 剖面视图、剖面
source: html/f4eda97d-14a0-c657-c916-83da00add998.htm
---
# Autodesk.Revit.DB.ViewSection.CreateReferenceCallout Method

**中文**: 剖面视图、剖面

Creates a new reference callout.

## Syntax (C#)
```csharp
public static void CreateReferenceCallout(
	Document document,
	ElementId parentViewId,
	ElementId viewIdToReference,
	XYZ point1,
	XYZ point2
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the new reference callout will be added.
- **parentViewId** (`Autodesk.Revit.DB.ElementId`) - The view in which the callout symbol appears.
 Callouts can be created in FloorPlan, CeilingPlan, StructuralPlan, Section, Elevation,
 Drafting, and Detail views.
- **viewIdToReference** (`Autodesk.Revit.DB.ElementId`) - The view which will be referenced. The ViewFamilyType of the referenced view will be used
 by the new reference callout.
 Only cropped views can be referenced, unless the referenced view is a Drafting view.
 Drafting views can always be referenced regardless of the parent view type.
 Elevation views can be referenced from Elevation and Drafting parent views.
 Section views can be referenced from Section and Drafting parent views.
 Detail views can be referenced from all parent views except for in FloorPlan, CeilingPlan and
 StructuralPlan parent views where only horizontally-oriented Detail views can be referenced.
 FloorPlan, CeilingPlan and StructuralPlan views can be referenced from FloorPlan, CeilingPlan
 and StructuralPlan parent views.
- **point1** (`Autodesk.Revit.DB.XYZ`) - One corner of the callout symbol in the parent view.
- **point2** (`Autodesk.Revit.DB.XYZ`) - The other diagonally opposed corner of the callout symbol in the parent view.

## Remarks
The reference callout will assume the ViewFamilyType of the view it references.
 The corners of the callout symbol will be determined by the two point arguments.
 The sides of the callout symbol will be aligned to the sides of the parent view's crop region.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId viewIdToReference does not correspond to a View.
 -or-
 The ElementId parentViewId does not correspond to a View.
 -or-
 The parent view and the referenced view must be different views.
 -or-
 The parent view does not support reference callouts to views of the ViewFamily used by viewIdToReference.
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

