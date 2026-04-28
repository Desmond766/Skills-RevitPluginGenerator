---
kind: method
id: M:Autodesk.Revit.DB.Analysis.ConceptualSurfaceType.GetByMassSubCategoryId(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/37f128bf-7dc3-3a39-7bf0-d307e5d5bcd5.htm
---
# Autodesk.Revit.DB.Analysis.ConceptualSurfaceType.GetByMassSubCategoryId Method

Get the ConceptualSurfaceType by its mass subcategory id.

## Syntax (C#)
```csharp
public static ConceptualSurfaceType GetByMassSubCategoryId(
	Document cda,
	ElementId massSubCategoryId
)
```

## Parameters
- **cda** (`Autodesk.Revit.DB.Document`) - The document.
- **massSubCategoryId** (`Autodesk.Revit.DB.ElementId`) - The mass subcategory id to get the ConceptualSurfaceType for.

## Returns
Returns ConceptualSurfaceType associated with input id or NULL.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The mass sub-category is none of the
 OST_MassInteriorWall,
 OST_MassExteriorWall,
 OST_MassExteriorWallUnderground,
 OST_MassRoof,
 OST_MassFloor,
 OST_MassSlab,
 OST_MassShade,
 OST_MassGlazing,
 OST_MassSkylights,
 or OST_MassOpening.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

