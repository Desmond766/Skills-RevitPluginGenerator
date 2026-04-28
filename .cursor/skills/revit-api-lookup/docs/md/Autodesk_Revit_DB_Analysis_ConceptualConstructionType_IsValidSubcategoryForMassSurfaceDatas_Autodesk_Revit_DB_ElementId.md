---
kind: method
id: M:Autodesk.Revit.DB.Analysis.ConceptualConstructionType.IsValidSubcategoryForMassSurfaceDatas(Autodesk.Revit.DB.ElementId)
source: html/75031bc8-15f5-cb88-1275-cb7d88ab04e4.htm
---
# Autodesk.Revit.DB.Analysis.ConceptualConstructionType.IsValidSubcategoryForMassSurfaceDatas Method

Validate if a subcategory is appropriate for assignment to Massing surfaces (MassSurfaceData).
 This is the list of acceptable values:
 OST_MassInteriorWall OST_MassExteriorWall OST_MassExteriorWallUnderground OST_MassRoof OST_MassFloor OST_MassSlab OST_MassShade OST_MassGlazing OST_MassSkylights OST_MassOpening

## Syntax (C#)
```csharp
public static bool IsValidSubcategoryForMassSurfaceDatas(
	ElementId massSubCategoryId
)
```

## Parameters
- **massSubCategoryId** (`Autodesk.Revit.DB.ElementId`) - The mass sub-category to be checked.

## Returns
True if the mass sub-category falls within the list, false otherwise.

## Remarks
This excludes sub-categories which are not actually sub-categories that
 can be assigned to surfaces, such as OST_MassWallsAll for example.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

