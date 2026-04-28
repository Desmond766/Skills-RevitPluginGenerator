---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.IsStructuralDeck(System.Int32)
source: html/bf8e5810-eb9e-125b-21bb-d43e406c6c39.htm
---
# Autodesk.Revit.DB.CompoundStructure.IsStructuralDeck Method

Determines whether a specified layer is a structural deck.

## Syntax (C#)
```csharp
public bool IsStructuralDeck(
	int layerIdx
)
```

## Parameters
- **layerIdx** (`System.Int32`) - Index of a layer in the CompoundStructure.

## Returns
True if specified layer is a structural deck, and false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The layer index is out of range.

