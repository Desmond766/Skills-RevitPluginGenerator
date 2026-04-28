---
kind: method
id: M:Autodesk.Revit.DB.ViewSection.CreateDetail(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.BoundingBoxXYZ)
zh: 剖面视图、剖面
source: html/834e7154-b2f0-ffcd-b04a-9ad8cee321c8.htm
---
# Autodesk.Revit.DB.ViewSection.CreateDetail Method

**中文**: 剖面视图、剖面

Returns a new detail ViewSection.

## Syntax (C#)
```csharp
public static ViewSection CreateDetail(
	Document document,
	ElementId viewFamilyTypeId,
	BoundingBoxXYZ sectionBox
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the new detail ViewSection will be added.
- **viewFamilyTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the ViewFamilyType which will be used by the new detail ViewSection. The type needs to be a Detail ViewFamily.
- **sectionBox** (`Autodesk.Revit.DB.BoundingBoxXYZ`) - The BoundingBoxXYZ which specifies the new ViewSection's view direction and extents.

## Returns
The new detail ViewSection.

## Remarks
Create a detail ViewSection whose view volume corresponds geometrically with the specified sectionBox.
 The view direction of the resulting section will be sectionBox.Transform.BasisZ and the up direction will
 be sectionBox.Transform.BasisY. The right hand direction will be computed so that (right, up, view direction)
 form a left handed coordinate system.
The resulting view will be cropped, and far clipping will be active.
 The crop region will correspond to the projections of BoundingBoxXYZ.Min and BoundingBoxXYZ.Max onto the view's cut plane.
 The far clip distance will be equal to the difference of the z-coordinates of BoundingBoxXYZ.Min and BoundingBoxXYZ.Max.
The new detail ViewSection will receive a unique view name.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ViewFamilyType must be a Detail ViewFamily.
 -or-
 The BoundingBoxXYZ is not appropriate for detail views.
 The basis vectors of must be unit length and orthonormal.
 The near and far bound offsets cannot be reversed or too close to each other.
 MinEnabled and MaxEnabled must be set to true for all three directions.
 -or-
 Detail section view creation is not allowed in this family.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

