---
kind: method
id: M:Autodesk.Revit.DB.MultiReferenceAnnotation.AreElementsValidForMultiReferenceAnnotation(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.MultiReferenceAnnotationOptions)
source: html/b49935de-bcad-70d0-cc8d-e53e4cb34031.htm
---
# Autodesk.Revit.DB.MultiReferenceAnnotation.AreElementsValidForMultiReferenceAnnotation Method

The method validates if the input elements match the element category id for the MultiReferenceAnnotationType.

## Syntax (C#)
```csharp
public static bool AreElementsValidForMultiReferenceAnnotation(
	Document document,
	MultiReferenceAnnotationOptions options
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document for the multi-reference annotation.
- **options** (`Autodesk.Revit.DB.MultiReferenceAnnotationOptions`) - The creation options for the new MultiReferenceAnnotation.

## Returns
Returns true if the input elements match the element category id for the MultiReferenceAnnotationType,
 false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

