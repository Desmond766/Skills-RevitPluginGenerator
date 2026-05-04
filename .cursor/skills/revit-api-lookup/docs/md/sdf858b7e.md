---
kind: property
id: P:Autodesk.Revit.DB.CombinableElement.Combinations
source: html/c7f28a22-305c-5006-87db-2719e91e58bb.htm
---
# Autodesk.Revit.DB.CombinableElement.Combinations Property

The geometry combinations that this element belongs to.

## Syntax (C#)
```csharp
public GeomCombinationSet Combinations { get; }
```

## Remarks
If this combinable element does not belong to any geometry combination, 
this value is an empty collection. A solid combinable element may belong to at most 
one combination, while a void combinable element may belong to multiple combinations.

