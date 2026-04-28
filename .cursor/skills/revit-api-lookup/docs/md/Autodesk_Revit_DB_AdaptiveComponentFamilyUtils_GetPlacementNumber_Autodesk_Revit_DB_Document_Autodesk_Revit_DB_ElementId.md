---
kind: method
id: M:Autodesk.Revit.DB.AdaptiveComponentFamilyUtils.GetPlacementNumber(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/57d96dcd-d97a-cda1-6afa-d8a294ba6672.htm
---
# Autodesk.Revit.DB.AdaptiveComponentFamilyUtils.GetPlacementNumber Method

Gets Placement number of an Adaptive Placement Point.

## Syntax (C#)
```csharp
public static int GetPlacementNumber(
	Document doc,
	ElementId refPointId
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The Document
- **refPointId** (`Autodesk.Revit.DB.ElementId`) - The ReferencePoint id

## Returns
Placement number of the Adaptive Placement Point.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId refPointId does not correspond to a valid ReferencePoint.
 -or-
 The Element corresponding to ElementId refPointId does not belong to an Adaptive Family.
 -or-
 The ElementId refPointId does not correspond to an Adaptive Placement Point.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

