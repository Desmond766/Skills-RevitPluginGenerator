---
kind: method
id: M:Autodesk.Revit.DB.Document.Paint(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Face,Autodesk.Revit.DB.FamilyParameter)
zh: 着色、上色、染色、填色
source: html/f59f8872-e8d7-5d00-0e8c-44a36a843861.htm
---
# Autodesk.Revit.DB.Document.Paint Method

**中文**: 着色、上色、染色、填色

Paint the element's face with specified material.

## Syntax (C#)
```csharp
public void Paint(
	ElementId elementId,
	Face face,
	FamilyParameter familyParameter
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The element that the face belongs to.
- **face** (`Autodesk.Revit.DB.Face`) - The painted element's face.
- **familyParameter** (`Autodesk.Revit.DB.FamilyParameter`) - The family parameter associated with a material.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element elementId does not exist in the document.
 -or-
 The element materialId does not exist in the document.
 -or-
 The face doesn't belongs to the element.
 -or-
 The family parameter doesn't specify a material element.
 -or-
 The element's face cannot be painted.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This document is not modifiable.
 -or-
 This operation is valid only in family.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

