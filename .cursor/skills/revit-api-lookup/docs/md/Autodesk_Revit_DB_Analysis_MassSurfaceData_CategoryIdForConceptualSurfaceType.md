---
kind: property
id: P:Autodesk.Revit.DB.Analysis.MassSurfaceData.CategoryIdForConceptualSurfaceType
source: html/ab56a667-e4a1-5a9f-9357-7aa40666b095.htm
---
# Autodesk.Revit.DB.Analysis.MassSurfaceData.CategoryIdForConceptualSurfaceType Property

Returns the mass subcategory ElementId used for ConceptualSurfaceType for this MassSurfaceData.

## Syntax (C#)
```csharp
public ElementId CategoryIdForConceptualSurfaceType { get; }
```

## Remarks
This value is determined by starting with the subcategory property and adjusting it according to properties
 such as "isSlab" or "isUnderground".

