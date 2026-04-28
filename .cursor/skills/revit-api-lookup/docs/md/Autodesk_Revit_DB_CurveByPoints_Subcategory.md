---
kind: property
id: P:Autodesk.Revit.DB.CurveByPoints.Subcategory
source: html/cbdc4354-9a30-6223-14a3-3f7ba66da2d8.htm
---
# Autodesk.Revit.DB.CurveByPoints.Subcategory Property

The subcategory, or graphics style, of the CurveByPoints.

## Syntax (C#)
```csharp
public GraphicsStyle Subcategory { get; set; }
```

## Remarks
If the family category is non-cuttable, the subcategory can be 
set to be the family category or one of its subcategories. 
If the family category is cuttable, the subcategory can be set as the graphics 
styles of the family category, its subcategories, or the invisible lines 
graphics style.

