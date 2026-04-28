---
kind: method
id: M:Autodesk.Revit.DB.Analysis.ConceptualConstructionType.GetFloorOrSlabConstructionType(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Analysis.ConceptualConstructionFloorSlabType)
source: html/4a20ade5-4456-b707-679e-ee4ef9e98b1f.htm
---
# Autodesk.Revit.DB.Analysis.ConceptualConstructionType.GetFloorOrSlabConstructionType Method

Get a Floor or Slab ConceptualConstructionType by its ConceptualConstructionFloorSlabType.

## Syntax (C#)
```csharp
public static ElementId GetFloorOrSlabConstructionType(
	Document ccda,
	ConceptualConstructionFloorSlabType typeEnum
)
```

## Parameters
- **ccda** (`Autodesk.Revit.DB.Document`) - The Document.
- **typeEnum** (`Autodesk.Revit.DB.Analysis.ConceptualConstructionFloorSlabType`) - The ConceptualConstructionFloorSlabType to get the ConceptualConstructionType for.

## Returns
Returns ElementId of a ConceptualConstructionType.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The enum is invalid for ConceptualConstructionFloorSlabType.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration

