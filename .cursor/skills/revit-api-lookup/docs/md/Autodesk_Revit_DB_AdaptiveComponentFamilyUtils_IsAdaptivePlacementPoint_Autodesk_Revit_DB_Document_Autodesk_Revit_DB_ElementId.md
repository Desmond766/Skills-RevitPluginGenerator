---
kind: method
id: M:Autodesk.Revit.DB.AdaptiveComponentFamilyUtils.IsAdaptivePlacementPoint(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/350e1a84-5110-4e61-704a-96edd790fab4.htm
---
# Autodesk.Revit.DB.AdaptiveComponentFamilyUtils.IsAdaptivePlacementPoint Method

Verifies if the Reference Point is an Adaptive Placement Point.

## Syntax (C#)
```csharp
public static bool IsAdaptivePlacementPoint(
	Document doc,
	ElementId refPointId
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The Document
- **refPointId** (`Autodesk.Revit.DB.ElementId`) - The ReferencePoint id

## Returns
True if the Point is an Adaptive Placement Point.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

