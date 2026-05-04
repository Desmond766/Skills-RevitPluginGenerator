---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.SetDeckEmbeddingType(System.Int32,Autodesk.Revit.DB.StructDeckEmbeddingType)
source: html/2f291187-825d-fb60-cd4a-33280dce91e4.htm
---
# Autodesk.Revit.DB.CompoundStructure.SetDeckEmbeddingType Method

Sets the deck embedding type to use for the specified structural deck.

## Syntax (C#)
```csharp
public void SetDeckEmbeddingType(
	int layerIdx,
	StructDeckEmbeddingType embedType
)
```

## Parameters
- **layerIdx** (`System.Int32`) - Index of a layer in the CompoundStructure.
- **embedType** (`Autodesk.Revit.DB.StructDeckEmbeddingType`) - The embedding type to be used by the specified layer if it is a structural deck.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The layer is not a structural deck.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The layer index is out of range.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration

