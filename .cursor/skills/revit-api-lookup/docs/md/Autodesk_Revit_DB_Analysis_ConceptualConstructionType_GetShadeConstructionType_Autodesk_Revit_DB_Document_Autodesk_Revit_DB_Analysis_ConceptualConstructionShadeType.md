---
kind: method
id: M:Autodesk.Revit.DB.Analysis.ConceptualConstructionType.GetShadeConstructionType(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Analysis.ConceptualConstructionShadeType)
source: html/363f5434-3f4a-5748-80f8-3279ee1d1067.htm
---
# Autodesk.Revit.DB.Analysis.ConceptualConstructionType.GetShadeConstructionType Method

Get a Shade ConceptualConstructionType by its ConceptualConstructionShadeType.

## Syntax (C#)
```csharp
public static ElementId GetShadeConstructionType(
	Document ccda,
	ConceptualConstructionShadeType typeEnum
)
```

## Parameters
- **ccda** (`Autodesk.Revit.DB.Document`) - The Document.
- **typeEnum** (`Autodesk.Revit.DB.Analysis.ConceptualConstructionShadeType`) - The ConceptualConstructionShadeType to get the ConceptualConstructionType for.

## Returns
Returns ElementId of a ConceptualConstructionType.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The enum is invalid for ConceptualConstructionShadeType.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration

