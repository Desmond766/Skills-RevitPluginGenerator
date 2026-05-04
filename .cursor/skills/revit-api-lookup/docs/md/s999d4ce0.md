---
kind: method
id: M:Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckGroundPlane(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/920b2575-1d5f-c3ce-599b-474764c59a4b.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckGroundPlane Method

The ground plane should be an Element of type Level. This method checks to confirm that an ElementId is for a Level element.

## Syntax (C#)
```csharp
public static bool CheckGroundPlane(
	Document ccda,
	ElementId groundPlaneId
)
```

## Parameters
- **ccda** (`Autodesk.Revit.DB.Document`) - The Document.
- **groundPlaneId** (`Autodesk.Revit.DB.ElementId`) - The element id to be checked to confirm that it is suitable to be a ground plane (i.e., that it is a level) or
 that it is invalidElementId. Setting ground plane with invalidElementId will lead to the ground plane being "reset".

## Returns
True if the input element is a level or invalidElementId, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

