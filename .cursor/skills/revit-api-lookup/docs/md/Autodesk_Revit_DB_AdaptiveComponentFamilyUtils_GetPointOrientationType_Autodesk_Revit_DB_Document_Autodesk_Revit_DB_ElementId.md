---
kind: method
id: M:Autodesk.Revit.DB.AdaptiveComponentFamilyUtils.GetPointOrientationType(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/6745f75e-ed08-4d2e-b402-5fc42093874b.htm
---
# Autodesk.Revit.DB.AdaptiveComponentFamilyUtils.GetPointOrientationType Method

Gets orientation type of an Adaptive Placement Point.

## Syntax (C#)
```csharp
public static AdaptivePointOrientationType GetPointOrientationType(
	Document doc,
	ElementId refPointId
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The Document
- **refPointId** (`Autodesk.Revit.DB.ElementId`) - The ReferencePoint id

## Returns
Orientation type of Adaptive Placement Point.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId refPointId does not correspond to a valid ReferencePoint.
 -or-
 The Element corresponding to ElementId refPointId does not belong to an Adaptive Family.
 -or-
 The ElementId refPointId does not correspond to an Adaptive Placement Point.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

