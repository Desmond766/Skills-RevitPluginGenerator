---
kind: property
id: P:Autodesk.Revit.DB.SymbolicCurve.Subcategory
source: html/dd07e20f-b6de-278e-3323-37c68306afd6.htm
---
# Autodesk.Revit.DB.SymbolicCurve.Subcategory Property

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

