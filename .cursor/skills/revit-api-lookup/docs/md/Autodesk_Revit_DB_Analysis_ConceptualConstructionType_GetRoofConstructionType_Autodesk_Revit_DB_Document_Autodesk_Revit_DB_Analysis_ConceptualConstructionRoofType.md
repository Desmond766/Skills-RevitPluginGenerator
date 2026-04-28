---
kind: method
id: M:Autodesk.Revit.DB.Analysis.ConceptualConstructionType.GetRoofConstructionType(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Analysis.ConceptualConstructionRoofType)
source: html/a7f16a35-0726-2a8b-369f-c64031c90e83.htm
---
# Autodesk.Revit.DB.Analysis.ConceptualConstructionType.GetRoofConstructionType Method

Get a Roof ConceptualConstructionType by its ConceptualConstructionRoofType.

## Syntax (C#)
```csharp
public static ElementId GetRoofConstructionType(
	Document ccda,
	ConceptualConstructionRoofType typeEnum
)
```

## Parameters
- **ccda** (`Autodesk.Revit.DB.Document`) - The Document.
- **typeEnum** (`Autodesk.Revit.DB.Analysis.ConceptualConstructionRoofType`) - The ConceptualConstructionRoofType to get the ConceptualConstructionType for.

## Returns
Returns ElementId of a ConceptualConstructionType.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The enum is invalid for ConceptualConstructionRoofType.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration

