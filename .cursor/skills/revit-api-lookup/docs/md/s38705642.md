---
kind: method
id: M:Autodesk.Revit.DB.MultiReferenceAnnotationOptions.SetAdditionalReferencesToDimension(System.Collections.Generic.IList{Autodesk.Revit.DB.Reference})
source: html/74d89f8a-88bd-a68b-b0ec-b1e5de920eb2.htm
---
# Autodesk.Revit.DB.MultiReferenceAnnotationOptions.SetAdditionalReferencesToDimension Method

Sets the additional references which the dimension will witness.

## Syntax (C#)
```csharp
public void SetAdditionalReferencesToDimension(
	IList<Reference> referencesToDimension
)
```

## Parameters
- **referencesToDimension** (`System.Collections.Generic.IList < Reference >`) - The additional references which the dimension will witness.

## Remarks
The additional references to dimension cannot come from the same category as the MultiReferenceAnnotationType's reference category.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Some references come from elements which directly match the reference category required by the MultiReferenceAnnotationType. For
 those elements please use SetElementsToDimension.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

