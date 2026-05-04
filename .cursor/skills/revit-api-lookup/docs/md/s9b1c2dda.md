---
kind: method
id: M:Autodesk.Revit.DB.Analysis.ConceptualConstructionType.IsValidConceptualConstructionIdForCategory(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/eaeb8997-5870-bd9a-6a41-58de6834e2cb.htm
---
# Autodesk.Revit.DB.Analysis.ConceptualConstructionType.IsValidConceptualConstructionIdForCategory Method

Indicate if a ConceptualConstruction is appropriate to assign to a MassSurfaceData of a particular Mass subcategory.

## Syntax (C#)
```csharp
public static bool IsValidConceptualConstructionIdForCategory(
	Document ccda,
	ElementId constructionTypeId,
	ElementId massSubcategoryId
)
```

## Parameters
- **ccda** (`Autodesk.Revit.DB.Document`) - The document.
- **constructionTypeId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the ConceptualConstructionType.
- **massSubcategoryId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the Mass subcategory.

## Returns
Returns true if valid, false otherwise

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId constructionTypeId is not an id of a ConceptualConstructionType.
 -or-
 The mass sub-category is none of the
 OST_MassInteriorWall,
 OST_MassExteriorWall,
 OST_MassExteriorWallUnderground,
 OST_MassWallsAll,
 OST_MassRoof,
 OST_MassFloor,
 OST_MassSlab,
 OST_MassFloorsAll,
 OST_MassShade,
 OST_MassGlazing,
 OST_MassSkylights,
 OST_MassGlazingAll
 or OST_MassOpening.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

