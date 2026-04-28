---
kind: method
id: M:Autodesk.Revit.DB.MultiReferenceAnnotationOptions.ReferencesDontMatchReferenceCategory(System.Collections.Generic.IList{Autodesk.Revit.DB.Reference})
source: html/c79310d9-a47c-7ad8-3fb3-6f5ce88cde34.htm
---
# Autodesk.Revit.DB.MultiReferenceAnnotationOptions.ReferencesDontMatchReferenceCategory Method

Verifies that all of the references belongs to elements which doesn't match the
 reference category required by the MultiReferenceAnnotationType.

## Syntax (C#)
```csharp
public bool ReferencesDontMatchReferenceCategory(
	IList<Reference> references
)
```

## Parameters
- **references** (`System.Collections.Generic.IList < Reference >`) - The references to test.

## Returns
Returns true if the element categories of all tested references do not match the element category required by the MultiReferenceAnnotationType.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

