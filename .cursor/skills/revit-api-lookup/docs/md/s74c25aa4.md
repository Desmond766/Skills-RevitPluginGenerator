---
kind: method
id: M:Autodesk.Revit.DB.Analysis.MassLevelData.IsValidConceptualConstructionTypeElement(Autodesk.Revit.DB.ElementId)
source: html/453bc7cc-a667-fdb6-72d9-efb2db40badd.htm
---
# Autodesk.Revit.DB.Analysis.MassLevelData.IsValidConceptualConstructionTypeElement Method

Checks if the ElementId is an acceptable conceptual construction type ElementId for the MassLevelData (Mass Floor).

## Syntax (C#)
```csharp
public bool IsValidConceptualConstructionTypeElement(
	ElementId id
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.ElementId`) - The ElementId to be checked.

## Returns
True if the ElementId is an acceptable conceptual construction type ElementId, false otherwise.

## Remarks
In the case that 'conceptualConstructionIsByEnergyData' is true, invalidElementId is also acceptable input.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

