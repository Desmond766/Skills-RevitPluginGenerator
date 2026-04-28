---
kind: method
id: M:Autodesk.Revit.DB.Analysis.ConceptualConstructionType.IsValidSurfaceSubcategoryForConstruction(Autodesk.Revit.DB.ElementId)
source: html/5f71a8d2-2c1f-427b-818b-139f01f33db5.htm
---
# Autodesk.Revit.DB.Analysis.ConceptualConstructionType.IsValidSurfaceSubcategoryForConstruction Method

Indicates if this ConceptualConstructionType is appropriate for the input MassSurfaceData subcategory.

## Syntax (C#)
```csharp
public bool IsValidSurfaceSubcategoryForConstruction(
	ElementId massSurfaceSubcategoryId
)
```

## Parameters
- **massSurfaceSubcategoryId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of a Mass subcategory of a MassSurfaceData.

## Returns
Returns true if appropriate for the input subcategory, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input Element massSurfaceSubcategoryId is not a valid subcategory value for MassSurfaceData.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

