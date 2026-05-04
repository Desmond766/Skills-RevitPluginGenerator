---
kind: method
id: M:Autodesk.Revit.DB.RadialArray.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.View,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId},System.Int32,Autodesk.Revit.DB.Line,System.Double,Autodesk.Revit.DB.ArrayAnchorMember)
zh: 创建、新建、生成、建立、新增
source: html/0bd37bef-5d5a-f65e-c05b-e4ef78ff6cb7.htm
---
# Autodesk.Revit.DB.RadialArray.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new radial array element from a set of elements based
 on an input rotation axis.

## Syntax (C#)
```csharp
public static RadialArray Create(
	Document aDoc,
	View dBView,
	ICollection<ElementId> ids,
	int count,
	Line axis,
	double angle,
	ArrayAnchorMember anchorMember
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - The document.
- **dBView** (`Autodesk.Revit.DB.View`) - The view. If it is a 2d view, translation vector must be in the view plane if elements include view-specific elements.
 If elements include view-specific elements, they must belong to this view.
- **ids** (`System.Collections.Generic.ICollection < ElementId >`) - The set of elements to array. The position of the rotation
 axis is determined by the cumulative center of the elements' bounding boxes.
- **count** (`System.Int32`) - The number of array members to create. The accepted range is from 3 to 200.
- **axis** (`Autodesk.Revit.DB.Line`) - The rotation axis.
- **angle** (`System.Double`) - The angle in radians of the rotation.
- **anchorMember** (`Autodesk.Revit.DB.ArrayAnchorMember`) - Indicates if the translation vector specifies the location of the second member
 of the array, or the last member of the array.

## Returns
The new radial array element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given element id set is empty.
 -or-
 One or more elements in ids do not exist in the document.
 -or-
 One or more elements in ids is owned by different views and thus cannot be arrayed together.
 -or-
 One or more elements in ids is not arrayable.
 -or-
 count must be between 3 and 200.
 -or-
 The view is invalid for specific view elements array.
 -or-
 The rotation axis is invalid to array the elements.
 -or-
 Angle value must be not zero.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to create the radial array.

