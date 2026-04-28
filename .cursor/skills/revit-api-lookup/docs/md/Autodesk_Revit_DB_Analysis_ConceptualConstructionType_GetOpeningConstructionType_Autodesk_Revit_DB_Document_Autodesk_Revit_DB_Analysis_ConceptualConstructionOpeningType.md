---
kind: method
id: M:Autodesk.Revit.DB.Analysis.ConceptualConstructionType.GetOpeningConstructionType(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Analysis.ConceptualConstructionOpeningType)
source: html/e8d1aefe-8978-d5af-706c-44a8b79027a1.htm
---
# Autodesk.Revit.DB.Analysis.ConceptualConstructionType.GetOpeningConstructionType Method

Get an Opening ConceptualConstructionType by its ConceptualConstructionOpeningType.

## Syntax (C#)
```csharp
public static ElementId GetOpeningConstructionType(
	Document ccda,
	ConceptualConstructionOpeningType typeEnum
)
```

## Parameters
- **ccda** (`Autodesk.Revit.DB.Document`) - The Document.
- **typeEnum** (`Autodesk.Revit.DB.Analysis.ConceptualConstructionOpeningType`) - The ConceptualConstructionOpeningType to get the ConceptualConstructionType for.

## Returns
Returns ElementId of a ConceptualConstructionType.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The enum is invalid for ConceptualConstructionOpeningType.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration

