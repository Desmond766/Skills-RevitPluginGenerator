---
kind: method
id: M:Autodesk.Revit.DB.CurveElement.SetTangentLock(System.Int32,Autodesk.Revit.DB.ElementId,System.Boolean)
source: html/34e01fde-176d-c53b-1a9e-bda92dbdf142.htm
---
# Autodesk.Revit.DB.CurveElement.SetTangentLock Method

Sets a new status for an existing tangent join with another curve element at the given end-point.

## Syntax (C#)
```csharp
public void SetTangentLock(
	int end,
	ElementId other,
	bool state
)
```

## Parameters
- **end** (`System.Int32`) - Index of one of the curve's ends. Values '0' and '1' indicate the start or end point, respectively.
- **other** (`Autodesk.Revit.DB.ElementId`) - ElementId of another Curve Element from the same document.
- **state** (`System.Boolean`) - Requested new state of the lock; True to lock it, False to unlock it.

## Remarks
The input status indicates whether the tangent join is to be locked or unlocked.
 Note that the status can be set only if this and the other curve element are currently
 joined and tangent at the given point. Locking a tangent join between elements of a family will make the family parametric.
 A parametric family needs to utilize a geometry solver in order to determine final
 shapes of its instances. Using the solver in families which contain large sketches
 may cause regenerations of such families to become significantly slower.
 To determine whether a particular family falls into such a category, programmers
 can query IsParametric property
 and [!:Autodesk::Revit::DB::Family::DoesContainLargeSketches()] 
 method of the Family class.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given Id does not represent any of the two end-points of a curve element.
 A valid value of either '0' or '1' is expected.
 -or-
 The given ElementId (%elementId) is not of a valid Curve Element.
 A valid Curve Element must be in the same document and must be
 diferent than this curve elements self.
 -or-
 This element has no tangent join with the input element at the given end-point.
 -or-
 The element other does not exist in the document containing this CurveElement
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This curve element does not support tangent joins with other elements.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - This CurveElement is an internal element, such as a component of a
 loaded family or a group type.
 -or-
 The document containing this CurveElement is in Group Edit Mode,
 Sketch Edit Mode, or Paste Mode, and the element is not a
 member of the group, sketch, or clipboard.
 -or-
 This CurveElement is a member of a group or sketch, and the document
 is not currently editing the group or sketch.
 -or-
 other is an internal element, such as a component of a
 loaded family or a group type.
 -or-
 The document containing other is in Group Edit Mode,
 Sketch Edit Mode, or Paste Mode, and the element is not a
 member of the group, sketch, or clipboard.
 -or-
 other is a member of a group or sketch, and the document
 is not currently editing the group or sketch.

