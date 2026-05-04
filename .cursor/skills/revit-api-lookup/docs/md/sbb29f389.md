---
kind: method
id: M:Autodesk.Revit.DB.MultiReferenceAnnotation.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.MultiReferenceAnnotationOptions)
zh: 创建、新建、生成、建立、新增
source: html/b3646880-ef76-d0d4-68d9-2c976163c340.htm
---
# Autodesk.Revit.DB.MultiReferenceAnnotation.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new MultiReferenceAnnotation.

## Syntax (C#)
```csharp
public static MultiReferenceAnnotation Create(
	Document document,
	ElementId ownerViewId,
	MultiReferenceAnnotationOptions options
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the new MultiReferenceAnnotation will be added.
- **ownerViewId** (`Autodesk.Revit.DB.ElementId`) - The view in which the multi-reference annotation will appear.
- **options** (`Autodesk.Revit.DB.MultiReferenceAnnotationOptions`) - The creation options for the new MultiReferenceAnnotation.

## Returns
The new MultiReferenceAnnotation.

## Remarks
New linear Dimension and IndependentTag elements will be created as children of the MultiReferenceAnnotation.
 The IndependentTag will only be created if the MultiReferenceAnnotationType property TagTypeId is valid.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 The ElementId ownerViewId does not correspond to a View.
 -or-
 The ElementId ownerViewId is a view template.
 -or-
 The ElementId ownerViewId is a perspective view.
 -or-
 The 3D view ownerViewId is not locked.
 -or-
 The input 3D view cannot be used to place a MultiReferenceAnnotation object.
 -or-
 dimension line direction and dimension plane normal are not orthogonal.
 -or-
 There is at least one element that doesn't match the reference category of the MultiReferenceAnnotationType, or there are no elements.
 -or-
 for DimensionStyleType LinearFixed dimensions the dimension line direction must be parallel to either the view's vertical or horizontal direction.
 -or-
 some references can't be used with a DimensionStyleType Linear dimension of this direction.
 References must either appear as points in the view or be linear references which are
 perpendicular to the dimension line.
 -or-
 some references can't be used with a DimensionStyleType LinearFixed dimension.
 Only references which appear as points in the view can be used.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

