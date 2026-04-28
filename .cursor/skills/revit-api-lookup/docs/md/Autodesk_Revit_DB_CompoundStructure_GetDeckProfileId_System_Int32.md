---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetDeckProfileId(System.Int32)
source: html/995814e7-0265-2472-82b7-8b46586e817c.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetDeckProfileId Method

Retrieves the profile loop used for the specified structural deck.

## Syntax (C#)
```csharp
public ElementId GetDeckProfileId(
	int layerIdx
)
```

## Parameters
- **layerIdx** (`System.Int32`) - Index of a layer in the CompoundStructure.

## Returns
The element id of a FamilySymbol which contains a profile loop used by a structural deck associated to the specified layer,
 or invalidElementId if isStructuralDeck(layerIdx) is false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The layer index is out of range.

