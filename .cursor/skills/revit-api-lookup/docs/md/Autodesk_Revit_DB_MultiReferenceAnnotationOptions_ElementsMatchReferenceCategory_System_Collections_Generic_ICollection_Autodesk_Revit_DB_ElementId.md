---
kind: method
id: M:Autodesk.Revit.DB.MultiReferenceAnnotationOptions.ElementsMatchReferenceCategory(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/a737d2a1-a595-4037-6038-79948d80c1e3.htm
---
# Autodesk.Revit.DB.MultiReferenceAnnotationOptions.ElementsMatchReferenceCategory Method

Verifies that all of the elements match the reference category required
 by the MultiReferenceAnnotationType.

## Syntax (C#)
```csharp
public bool ElementsMatchReferenceCategory(
	ICollection<ElementId> elements
)
```

## Parameters
- **elements** (`System.Collections.Generic.ICollection < ElementId >`) - The elements to test.

## Returns
True if all the elements match the reference category required by the MultiReferenceAnnotationType.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

