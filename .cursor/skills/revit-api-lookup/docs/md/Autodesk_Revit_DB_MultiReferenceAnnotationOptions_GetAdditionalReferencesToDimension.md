---
kind: method
id: M:Autodesk.Revit.DB.MultiReferenceAnnotationOptions.GetAdditionalReferencesToDimension
source: html/a53c4ebf-0a34-31b5-9140-27dcd15f85f2.htm
---
# Autodesk.Revit.DB.MultiReferenceAnnotationOptions.GetAdditionalReferencesToDimension Method

Gets the additional references which the dimension will witness.

## Syntax (C#)
```csharp
public IList<Reference> GetAdditionalReferencesToDimension()
```

## Returns
The additional references which the dimension will witness.

## Remarks
These references may be to elements of other categories than the reference category returned by MultiReferenceAnnotationType.

