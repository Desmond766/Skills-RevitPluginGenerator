---
kind: method
id: M:Autodesk.Revit.DB.Analysis.ConceptualConstructionType.GetGBSId(Autodesk.Revit.DB.ElementId)
source: html/75f60a0b-3afa-13b7-559a-b70122c92fad.htm
---
# Autodesk.Revit.DB.Analysis.ConceptualConstructionType.GetGBSId Method

Gets the Green Building Studio identifier associated with the construction.

## Syntax (C#)
```csharp
public int GetGBSId(
	ElementId massSurfaceSubCategoryId
)
```

## Parameters
- **massSurfaceSubCategoryId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of a valid Mass subcategory of a MassSurfaceData.

## Returns
Returns the integer id used to represent the ConceptualConstructionType.

## Remarks
Sometimes the GBSId is different for the same ConceptualConstructionType depending on the
 mass subcategory it is related to. This is usually the case, for example, for window and skylight
 constructions, which do not share GBSid's even when they share ConceptualConstructionTypes.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input Element massSurfaceSubCategoryId is not a valid subcategory value for MassSurfaceData.
 -or-
 The ElementId massSurfaceSubCategoryId is not appropriate for this ConceptualConstructionType.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

