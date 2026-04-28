---
kind: method
id: M:Autodesk.Revit.DB.Analysis.ConceptualConstructionType.GetWallConstructionType(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Analysis.ConceptualConstructionWallType)
source: html/e331e491-dfd1-0eb5-a9bf-66ee72297d9e.htm
---
# Autodesk.Revit.DB.Analysis.ConceptualConstructionType.GetWallConstructionType Method

Get a Wall ConceptualConstructionType by its ConceptualConstructionWallType.

## Syntax (C#)
```csharp
public static ElementId GetWallConstructionType(
	Document ccda,
	ConceptualConstructionWallType typeEnum
)
```

## Parameters
- **ccda** (`Autodesk.Revit.DB.Document`) - The Document.
- **typeEnum** (`Autodesk.Revit.DB.Analysis.ConceptualConstructionWallType`) - The ConceptualConstructionWallType to get the ConceptualConstructionType for.

## Returns
Returns ElementId of a ConceptualConstructionType.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The enum is invalid for ConceptualConstructionWallType.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration

