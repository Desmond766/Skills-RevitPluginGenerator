---
kind: method
id: M:Autodesk.Revit.DB.LinearArray.ArrayElementWithoutAssociation(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.View,Autodesk.Revit.DB.ElementId,System.Int32,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.ArrayAnchorMember)
source: html/260ee73e-2196-79a3-19ac-f942aafc44f4.htm
---
# Autodesk.Revit.DB.LinearArray.ArrayElementWithoutAssociation Method

Creates a new linear array from a single element.

## Syntax (C#)
```csharp
public static ICollection<ElementId> ArrayElementWithoutAssociation(
	Document aDoc,
	View dBView,
	ElementId id,
	int count,
	XYZ translationToAnchorMember,
	ArrayAnchorMember anchorMember
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - The document.
- **dBView** (`Autodesk.Revit.DB.View`) - The view. If it is a 2d view, translation vector must be in the view plane if the element is a view-specific element.
- **id** (`Autodesk.Revit.DB.ElementId`) - The element to array.
- **count** (`System.Int32`) - The number of array members to create including the initial
 element grouping. Must between 2 and 200.
- **translationToAnchorMember** (`Autodesk.Revit.DB.XYZ`) - The translation vector for the array.
- **anchorMember** (`Autodesk.Revit.DB.ArrayAnchorMember`) - Indicates if the translation vector specifies the location of the second member
 of the array, or the last member of the array.

## Returns
The ids of the elements created during the operation.

## Remarks
The resulting elements will not be associated with an array element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element id does not exist in the document
 -or-
 id is not arrayable.
 -or-
 count must be between 2 and 200.
 -or-
 The view is invalid for specific view elements array.
 -or-
 The translation point vector is invalid to array the element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to create the linear array.

