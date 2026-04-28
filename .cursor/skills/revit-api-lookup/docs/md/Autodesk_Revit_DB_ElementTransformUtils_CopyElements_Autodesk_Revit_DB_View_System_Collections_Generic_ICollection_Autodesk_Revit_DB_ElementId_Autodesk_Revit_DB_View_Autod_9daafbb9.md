---
kind: method
id: M:Autodesk.Revit.DB.ElementTransformUtils.CopyElements(Autodesk.Revit.DB.View,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId},Autodesk.Revit.DB.View,Autodesk.Revit.DB.Transform,Autodesk.Revit.DB.CopyPasteOptions)
zh: 复制
source: html/0f6a7a2e-13b9-008a-4c41-951a0702d16b.htm
---
# Autodesk.Revit.DB.ElementTransformUtils.CopyElements Method

**中文**: 复制

Copies a set of elements from source view to destination view.

## Syntax (C#)
```csharp
public static ICollection<ElementId> CopyElements(
	View sourceView,
	ICollection<ElementId> elementsToCopy,
	View destinationView,
	Transform additionalTransform,
	CopyPasteOptions options
)
```

## Parameters
- **sourceView** (`Autodesk.Revit.DB.View`) - The view in the source document that contains the elements to copy.
- **elementsToCopy** (`System.Collections.Generic.ICollection < ElementId >`) - The set of elements to copy.
- **destinationView** (`Autodesk.Revit.DB.View`) - The view in the destination document that the elements will be pasted into.
- **additionalTransform** (`Autodesk.Revit.DB.Transform`) - The transform for the new elements, in addition to the transformation between the source and destination views. Can be Nothing nullptr a null reference ( Nothing in Visual Basic) if no transform is required. The transformation must be within the plane of the destination view.
- **options** (`Autodesk.Revit.DB.CopyPasteOptions`) - Optional settings. Can be Nothing nullptr a null reference ( Nothing in Visual Basic) if default settings should be used.

## Returns
The ids of the newly created copied elements.

## Remarks
This method can be used for both view-specific and model elements. Both source and destination views must be 2D graphics views capable of drawing details and view-specific elements (floor and ceiling plans, elevations, sections, drafting views.)
 Drafting views cannot be used as a destination for model elements. The pasted elements are repositioned to ensure proper placement in the destination view (e.g. elevation is changed when copying from a level to a different level.)
 Additional transformation within the destination view can be performed by providing additionalTransform argument. This additional transformation must be within the plane of the destination view. The destination view can be in the same document as the source view. The destination view can be the same as the source view. All view-specific elements in the set must be specific to the source view. Elements specific to views other than the source view or to multiple views cannot be copied. This method performs rehosting of elements where applicable.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given element id set is empty.
 -or-
 The specified view cannot be used as a source or destination for copying elements between two views.
 -or-
 Some of the elements cannot be copied, because they belong to a different document.
 -or-
 Some of the elements cannot be copied, because they belong to a different view.
 -or-
 The elements cannot be copied into the destination view. Drafting views cannot contain model elements.
 -or-
 The transformation is not within the plane of the destination view.
 -or-
 The input set of elements contains Sketch members along with other elements and the Sketch Id of those members isn't in the set.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - It is not allowed to copy Sketch members between non-parallel sketches.
 -or-
 The elements cannot be copied.
- **Autodesk.Revit.Exceptions.OperationCanceledException** - User cancelled the operation.

