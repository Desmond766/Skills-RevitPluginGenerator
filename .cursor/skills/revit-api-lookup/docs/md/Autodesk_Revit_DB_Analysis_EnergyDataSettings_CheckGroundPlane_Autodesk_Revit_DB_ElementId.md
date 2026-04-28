---
kind: method
id: M:Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckGroundPlane(Autodesk.Revit.DB.ElementId)
source: html/d0ae01ec-29a6-d956-5e21-2de19191f9c7.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckGroundPlane Method

The ground plane should be an Element of type Level. This method checks to confirm that an ElementId is for a Level element.

## Syntax (C#)
```csharp
public bool CheckGroundPlane(
	ElementId groundPlaneId
)
```

## Parameters
- **groundPlaneId** (`Autodesk.Revit.DB.ElementId`) - The element id to be checked to confirm that it is suitable to be a ground plane (i.e., that it is a level) or
 that it is invalidElementId. Setting ground plane with invalidElementId will lead to the ground plane being "reset".

## Returns
True if the input element is a level or invalidElementId, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

