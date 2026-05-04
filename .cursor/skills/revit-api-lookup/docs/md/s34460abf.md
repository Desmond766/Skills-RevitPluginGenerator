---
kind: method
id: M:Autodesk.Revit.DB.RadialArray.ArrayElementWithoutAssociation(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.View,Autodesk.Revit.DB.ElementId,System.Int32,Autodesk.Revit.DB.Line,System.Double,Autodesk.Revit.DB.ArrayAnchorMember)
source: html/248559b9-c065-e05b-e8df-d60e8ed5e47d.htm
---
# Autodesk.Revit.DB.RadialArray.ArrayElementWithoutAssociation Method

Creates a new radial array from a single element based
 on an input rotation axis.

## Syntax (C#)
```csharp
public static ICollection<ElementId> ArrayElementWithoutAssociation(
	Document aDoc,
	View dBView,
	ElementId id,
	int count,
	Line axis,
	double angle,
	ArrayAnchorMember anchorMember
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - The view. If it is a 2d view, translation vector must be in the view plane if the element is a view-specific element.
- **dBView** (`Autodesk.Revit.DB.View`) - The view.
- **id** (`Autodesk.Revit.DB.ElementId`) - The element to array. The position of the rotation
 axis is determined by the center of the element's bounding boxes.
- **count** (`System.Int32`) - The number of array members to create. The accepted range is from 3 to 200.
- **axis** (`Autodesk.Revit.DB.Line`) - The rotation axis.
- **angle** (`System.Double`) - The angle in radians of the rotation.
- **anchorMember** (`Autodesk.Revit.DB.ArrayAnchorMember`) - Indicates if the translation vector specifies the location of the second member
 of the array, or the last member of the array.

## Returns
The elements created by the operation.

## Remarks
The resulting elements will not be associated with an array element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element id does not exist in the document
 -or-
 id is not arrayable.
 -or-
 count must be between 3 and 200.
 -or-
 The view is invalid for specific view elements array.
 -or-
 The rotation axis is invalid to array the element.
 -or-
 Angle value must be not zero.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to create the radial array.

