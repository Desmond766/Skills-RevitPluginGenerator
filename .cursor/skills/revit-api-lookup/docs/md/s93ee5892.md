---
kind: method
id: M:Autodesk.Revit.DB.DisplacementElement.Create(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId},Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.View,Autodesk.Revit.DB.DisplacementElement)
zh: 创建、新建、生成、建立、新增
source: html/891b2088-81e0-aa88-5e8b-3ffacc3d35a3.htm
---
# Autodesk.Revit.DB.DisplacementElement.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new DisplacementElement as a child of the specified parent DisplacementElement.

## Syntax (C#)
```csharp
public static DisplacementElement Create(
	Document document,
	ICollection<ElementId> elementsToDisplace,
	XYZ displacement,
	View ownerDBView,
	DisplacementElement parentDisplacementElement
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Document
- **elementsToDisplace** (`System.Collections.Generic.ICollection < ElementId >`) - The elements to be displaced.
- **displacement** (`Autodesk.Revit.DB.XYZ`) - The translation to be applied to the graphics of the displaced elements.
- **ownerDBView** (`Autodesk.Revit.DB.View`) - The 3D view which will own the DisplacementElement.
- **parentDisplacementElement** (`Autodesk.Revit.DB.DisplacementElement`) - An existing DisplacementElement that will be the parent of the one being created.
 It must be owned by ownerDBView.
 The relative transform of new DisplacementElement will be concatenated with the
 absolute transform of the parent DisplacementElement.
 If the elements specified by displacedElemIds are already displaced by another
 DisplacementElement, then this must be that element.

## Returns
The id of the new DisplacementElement.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - #elementIds# contains no element ids.
 -or-
 ownerDBView is not a 3D view.
 -or-
 For each individual element in the set elementsToDisplace, isAllowedAsDisplacedElement must return true, and the
 elements must either not already be displaced in the specified view, or else they
 must all be displaced by the same displacement element in the view.
 -or-
 The DisplacementElement parentDisplacementElement in not owned by the view ownerDBView.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

