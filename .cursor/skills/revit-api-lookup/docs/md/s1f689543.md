---
kind: method
id: M:Autodesk.Revit.DB.Document.Paint(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Face,Autodesk.Revit.DB.ElementId)
zh: 着色、上色、染色、填色
source: html/9268395e-a9cb-ff79-20ab-1ed261220513.htm
---
# Autodesk.Revit.DB.Document.Paint Method

**中文**: 着色、上色、染色、填色

Paint the element's face with specified material.

## Syntax (C#)
```csharp
public void Paint(
	ElementId elementId,
	Face face,
	ElementId materialId
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The element that the face belongs to.
- **face** (`Autodesk.Revit.DB.Face`) - The painted element's face.
- **materialId** (`Autodesk.Revit.DB.ElementId`) - The material to be painted on the face

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element elementId does not exist in the document
 -or-
 The element materialId does not exist in the document
 -or-
 The face doesn't belong to the element
 -or-
 The materialId doesn't specify a material element.
 -or-
 The element's face cannot be painted.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

