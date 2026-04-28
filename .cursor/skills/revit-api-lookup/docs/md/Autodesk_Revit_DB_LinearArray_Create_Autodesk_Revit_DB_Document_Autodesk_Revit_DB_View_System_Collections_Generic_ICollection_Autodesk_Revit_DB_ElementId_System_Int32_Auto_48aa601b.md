---
kind: method
id: M:Autodesk.Revit.DB.LinearArray.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.View,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId},System.Int32,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.ArrayAnchorMember)
zh: 创建、新建、生成、建立、新增
source: html/77e8c92f-6b48-0f3d-923c-2737a6d6e4ab.htm
---
# Autodesk.Revit.DB.LinearArray.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new linear array element from a set of elements.

## Syntax (C#)
```csharp
public static LinearArray Create(
	Document aDoc,
	View dBView,
	ICollection<ElementId> ids,
	int count,
	XYZ translationToAnchorMember,
	ArrayAnchorMember anchorMember
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - The document.
- **dBView** (`Autodesk.Revit.DB.View`) - The view. If it is a 2d view, translation vector must be in the view plane if elements include view-specific elements.
 If elements include view-specific elements, they must belong to this view.
- **ids** (`System.Collections.Generic.ICollection < ElementId >`) - The elements to array.
- **count** (`System.Int32`) - The number of array members to create including the initial
 element grouping. Must between 2 and 200.
- **translationToAnchorMember** (`Autodesk.Revit.DB.XYZ`) - The translation vector for the array.
- **anchorMember** (`Autodesk.Revit.DB.ArrayAnchorMember`) - Indicates if the translation vector specifies the location of the second member
 of the array, or the last member of the array.

## Returns
The new linear array element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given element id set is empty.
 -or-
 One or more elements in ids do not exist in the document.
 -or-
 One or more elements in ids is owned by different views and thus cannot be arrayed together.
 -or-
 One or more elements in ids is not arrayable.
 -or-
 count must be between 2 and 200.
 -or-
 The view is invalid for specific view elements array.
 -or-
 The translation point vector is invalid to array the element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to create the linear array.

