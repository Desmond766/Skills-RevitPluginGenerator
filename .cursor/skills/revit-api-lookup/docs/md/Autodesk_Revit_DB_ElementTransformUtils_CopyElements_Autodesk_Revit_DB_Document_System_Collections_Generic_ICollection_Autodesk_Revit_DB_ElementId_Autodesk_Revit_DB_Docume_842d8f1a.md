---
kind: method
id: M:Autodesk.Revit.DB.ElementTransformUtils.CopyElements(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId},Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Transform,Autodesk.Revit.DB.CopyPasteOptions)
zh: 复制
source: html/b22df8f6-3fa3-e177-ffa5-ba6c639fb3dc.htm
---
# Autodesk.Revit.DB.ElementTransformUtils.CopyElements Method

**中文**: 复制

Copies a set of elements from source document to destination document.

## Syntax (C#)
```csharp
public static ICollection<ElementId> CopyElements(
	Document sourceDocument,
	ICollection<ElementId> elementsToCopy,
	Document destinationDocument,
	Transform transform,
	CopyPasteOptions options
)
```

## Parameters
- **sourceDocument** (`Autodesk.Revit.DB.Document`) - The document that contains the elements to copy.
- **elementsToCopy** (`System.Collections.Generic.ICollection < ElementId >`) - The set of elements to copy.
- **destinationDocument** (`Autodesk.Revit.DB.Document`) - The destination document to paste the elements into.
- **transform** (`Autodesk.Revit.DB.Transform`) - The transform for the new elements. Can be Nothing nullptr a null reference ( Nothing in Visual Basic) if no transform is required.
- **options** (`Autodesk.Revit.DB.CopyPasteOptions`) - Optional settings. Can be Nothing nullptr a null reference ( Nothing in Visual Basic) if default settings should be used.

## Returns
The ids of the newly created copied elements.

## Remarks
Copies are placed at their respective original locations or locations specified by the optional transformation. This method can be used for copying non-view specific elements only. For copying view-specific elements, use the view-specific form of the CopyElements method. The destination document can be the same as the source document. This method performs rehosting of elements where applicable.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given element id set is empty.
 -or-
 One or more elements in elementsToCopy do not exist in the document.
 -or-
 Some of the elements cannot be copied, because they are view-specific.
 -or-
 The input set of elements contains Sketch members along with other elements or there is no active Sketch edit mode.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - It is not allowed to copy Sketch members between non-parallel sketches.
 -or-
 The elements cannot be copied.
- **Autodesk.Revit.Exceptions.OperationCanceledException** - User cancelled the operation.

