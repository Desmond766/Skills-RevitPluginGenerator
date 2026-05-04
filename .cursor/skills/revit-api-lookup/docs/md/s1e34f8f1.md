---
kind: method
id: M:Autodesk.Revit.DB.Architecture.NonContinuousRailInfo.IsValidNonContinuousRailMaterial(Autodesk.Revit.DB.ElementId)
source: html/646e7c56-e9e2-78db-9e2a-dda5b9cb04bd.htm
---
# Autodesk.Revit.DB.Architecture.NonContinuousRailInfo.IsValidNonContinuousRailMaterial Method

Checks whether an ElementId is a valid material Id of a non-continuous rail.

## Syntax (C#)
```csharp
public bool IsValidNonContinuousRailMaterial(
	ElementId materialId
)
```

## Parameters
- **materialId** (`Autodesk.Revit.DB.ElementId`) - The material Id to be checked.

## Returns
True if the ElementId refers to a valid material or it is invalidElementId, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

