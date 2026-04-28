---
kind: method
id: M:Autodesk.Revit.DB.Analysis.ConceptualConstructionType.GetAllConceptualConstructionsForCategory(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/3752bcdb-0982-44cc-e31c-2c2ccf4c86e9.htm
---
# Autodesk.Revit.DB.Analysis.ConceptualConstructionType.GetAllConceptualConstructionsForCategory Method

Get all the ids of constructions applicable to the input massSubCategory

## Syntax (C#)
```csharp
public static ICollection<ElementId> GetAllConceptualConstructionsForCategory(
	Document ccda,
	ElementId massSubCategoryId
)
```

## Parameters
- **ccda** (`Autodesk.Revit.DB.Document`) - The document.
- **massSubCategoryId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the mass subcategory.

## Returns
Returns a set of ElementIds that for the ConceptualConstructionTypes that are appropriate for the subcategory.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The mass sub-category is none of the
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

