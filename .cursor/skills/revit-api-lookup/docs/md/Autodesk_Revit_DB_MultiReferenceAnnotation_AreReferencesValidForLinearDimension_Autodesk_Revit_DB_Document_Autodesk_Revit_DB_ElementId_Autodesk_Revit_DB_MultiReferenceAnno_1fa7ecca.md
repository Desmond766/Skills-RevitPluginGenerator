---
kind: method
id: M:Autodesk.Revit.DB.MultiReferenceAnnotation.AreReferencesValidForLinearDimension(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.MultiReferenceAnnotationOptions)
source: html/3e6aaebc-28a1-da82-8022-ec76d26122c6.htm
---
# Autodesk.Revit.DB.MultiReferenceAnnotation.AreReferencesValidForLinearDimension Method

If the DimensionStyleType is Linear, validates that the references are valid
 for an aligned multi-reference annotation.

## Syntax (C#)
```csharp
public static bool AreReferencesValidForLinearDimension(
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
True DimensionStyleType does not equal Linear or
 if an aligned multi-reference annotation can be created from the references.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

