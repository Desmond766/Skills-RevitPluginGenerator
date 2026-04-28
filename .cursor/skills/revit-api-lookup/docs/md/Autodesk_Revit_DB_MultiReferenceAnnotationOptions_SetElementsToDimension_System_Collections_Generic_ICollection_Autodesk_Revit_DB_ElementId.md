---
kind: method
id: M:Autodesk.Revit.DB.MultiReferenceAnnotationOptions.SetElementsToDimension(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/18bf692f-0adf-bf2f-6996-ee3ded0b7bc1.htm
---
# Autodesk.Revit.DB.MultiReferenceAnnotationOptions.SetElementsToDimension Method

Sets the elements which the dimension will witness.

## Syntax (C#)
```csharp
public void SetElementsToDimension(
	ICollection<ElementId> elementsToDimension
)
```

## Parameters
- **elementsToDimension** (`System.Collections.Generic.ICollection < ElementId >`) - The elements which the dimension will witness.

## Remarks
The dimension will automatically find geometric references in the elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - some elements do not match the reference category required by the MultiReferenceAnnotationType.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The MultiReferenceAnnotationType assigned to the options can't create MultiReferenceAnnotations by element.

