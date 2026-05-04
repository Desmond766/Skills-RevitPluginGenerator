---
kind: property
id: P:Autodesk.Revit.DB.ModelCurve.Subcategory
source: html/639b74b2-1dca-0d4a-49f6-1df4b8213f19.htm
---
# Autodesk.Revit.DB.ModelCurve.Subcategory Property

The subcategory.

## Syntax (C#)
```csharp
public GraphicsStyle Subcategory { get; set; }
```

## Remarks
If the family category is non-cuttable, the subcategory can be 
set to be the family category or one of its subcategories. 
If the family category is cuttable, the subcategory can be set as the graphics 
styles of the family category, its subcategories, or the invisible lines graphics style.

