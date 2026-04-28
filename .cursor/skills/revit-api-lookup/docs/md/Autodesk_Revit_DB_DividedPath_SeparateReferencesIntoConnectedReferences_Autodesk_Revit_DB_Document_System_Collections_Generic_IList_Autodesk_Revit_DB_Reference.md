---
kind: method
id: M:Autodesk.Revit.DB.DividedPath.SeparateReferencesIntoConnectedReferences(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.Reference})
source: html/ec343b67-2254-380b-8802-924d632a1ae6.htm
---
# Autodesk.Revit.DB.DividedPath.SeparateReferencesIntoConnectedReferences Method

This function separates the input curve references into groups of connected curve references.
 Each group of connected curve references can be used to create a divided path.

## Syntax (C#)
```csharp
public static IList<IList<Reference>> SeparateReferencesIntoConnectedReferences(
	Document document,
	IList<Reference> curveReferences
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **curveReferences** (`System.Collections.Generic.IList < Reference >`) - The references.

## Returns
The grouped references

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Not all curve references in curveReferences represent a curve or an edge
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - this operation failed.

