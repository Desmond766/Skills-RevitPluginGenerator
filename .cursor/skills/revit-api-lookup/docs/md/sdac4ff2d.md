---
kind: method
id: M:Autodesk.Revit.DB.MultiReferenceAnnotation.AreReferencesValidForLinearFixedDimension(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.MultiReferenceAnnotationOptions)
source: html/75111b29-eff1-c970-7f70-ba3cbcf7766e.htm
---
# Autodesk.Revit.DB.MultiReferenceAnnotation.AreReferencesValidForLinearFixedDimension Method

If the DimensionStyleType is LinearFixed, validates that the references are valid
 for an aligned multi-reference annotation.

## Syntax (C#)
```csharp
public static bool AreReferencesValidForLinearFixedDimension(
	Document document,
	ElementId ownerViewId,
	MultiReferenceAnnotationOptions options
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document for the multi-reference annotation.
- **ownerViewId** (`Autodesk.Revit.DB.ElementId`) - The view in which the multi-reference annotation will appear.
- **options** (`Autodesk.Revit.DB.MultiReferenceAnnotationOptions`) - Options containing the references which the dimension will witness.

## Returns
True DimensionStyleType does not equal LinearFixed or
 if an aligned multi-reference annotation can be created from the references.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

