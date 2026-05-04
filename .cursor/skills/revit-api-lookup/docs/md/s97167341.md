---
kind: method
id: M:Autodesk.Revit.DB.ViewSection.CreateReferenceSection(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
zh: 剖面视图、剖面
source: html/614dd5eb-9b9c-cf32-a34f-08338afc9a18.htm
---
# Autodesk.Revit.DB.ViewSection.CreateReferenceSection Method

**中文**: 剖面视图、剖面

Creates a new reference section.

## Syntax (C#)
```csharp
public static void CreateReferenceSection(
	Document document,
	ElementId parentViewId,
	ElementId viewIdToReference,
	XYZ headPoint,
	XYZ tailPoint
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the reference section will be added.
- **parentViewId** (`Autodesk.Revit.DB.ElementId`) - The view in which the new reference section marker will appear.
 Reference sections can be created in FloorPlan, CeilingPlan, StructuralPlan, Section, Elevation,
 Drafting, and Detail views.
- **viewIdToReference** (`Autodesk.Revit.DB.ElementId`) - Detail, Drafting and Section views can be referenced.
 The ViewFamilyType of the referenced view will be used by the new reference section.
- **headPoint** (`Autodesk.Revit.DB.XYZ`) - Determines the location of the section marker's head in the parent view.
- **tailPoint** (`Autodesk.Revit.DB.XYZ`) - Determines the location of the section marker's tail in the parent view.

## Remarks
The reference section will assume the ViewFamilyType of the view it references.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId viewIdToReference does not correspond to a View.
 -or-
 The ElementId parentViewId does not correspond to a View.
 -or-
 The parent view and the referenced view must be different views.
 -or-
 Can't create a new reference sections in parentViewId. Parent views must be
 FloorPlan, CeilingPlan, StructuralPlan, Section, Elevation, Drafting, or Detail views.
 -or-
 The viewIdToReference cannot be referenced by reference sections. Only Detail, Drafting and Section views can be referenced.
 -or-
 headPoint and tailPoint do not differ when projected onto a plane perpendicular to the view direction.
 -or-
 Reference section view creation is not allowed in this family.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

