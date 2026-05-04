---
kind: method
id: M:Autodesk.Revit.DB.Analysis.ConceptualConstructionType.IsValidConceptualConstructionId(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/220c0588-536a-5806-6d35-54dbb4110ef2.htm
---
# Autodesk.Revit.DB.Analysis.ConceptualConstructionType.IsValidConceptualConstructionId Method

Indicates if the ElementId is an id of a ConceptualConstructionType.

## Syntax (C#)
```csharp
public static bool IsValidConceptualConstructionId(
	Document ccda,
	ElementId constructionTypeId
)
```

## Parameters
- **ccda** (`Autodesk.Revit.DB.Document`) - The document.
- **constructionTypeId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the ConceptualConstructionType.

## Returns
Returns true if is an id of a ConceptualConstructionType, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

