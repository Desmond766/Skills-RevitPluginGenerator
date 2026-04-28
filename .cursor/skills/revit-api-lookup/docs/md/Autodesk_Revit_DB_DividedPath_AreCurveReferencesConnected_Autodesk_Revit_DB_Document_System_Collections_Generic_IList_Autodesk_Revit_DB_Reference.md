---
kind: method
id: M:Autodesk.Revit.DB.DividedPath.AreCurveReferencesConnected(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.Reference})
source: html/09b53bab-9266-08d6-f620-97d3f09b8756.htm
---
# Autodesk.Revit.DB.DividedPath.AreCurveReferencesConnected Method

This checks if the references represent a connected set of curves as required by the divided path.

## Syntax (C#)
```csharp
public static bool AreCurveReferencesConnected(
	Document document,
	IList<Reference> curveReferences
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **curveReferences** (`System.Collections.Generic.IList < Reference >`) - The references.

## Returns
True if the arguments passed the checks, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

