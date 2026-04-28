---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.SetDeckProfileId(System.Int32,Autodesk.Revit.DB.ElementId)
source: html/53707358-b988-204a-7038-708bd47ca835.htm
---
# Autodesk.Revit.DB.CompoundStructure.SetDeckProfileId Method

Sets the profile loop to use for the specified structural deck.

## Syntax (C#)
```csharp
public void SetDeckProfileId(
	int layerIdx,
	ElementId profileId
)
```

## Parameters
- **layerIdx** (`System.Int32`) - Index of a layer in the CompoundStructure.
- **profileId** (`Autodesk.Revit.DB.ElementId`) - The element id of a FamilySymbol which contains a profile loop to be used by the specified layer if it is a structural deck.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The layer is not a structural deck.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The layer index is out of range.

