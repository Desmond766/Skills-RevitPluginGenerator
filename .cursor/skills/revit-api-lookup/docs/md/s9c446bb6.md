---
kind: method
id: M:Autodesk.Revit.DB.AdaptiveComponentFamilyUtils.SetPointOrientationType(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.AdaptivePointOrientationType)
source: html/55ddb006-29fa-8f47-1f80-1e3e63158715.htm
---
# Autodesk.Revit.DB.AdaptiveComponentFamilyUtils.SetPointOrientationType Method

Sets orientation type of an Adaptive Placement Point.

## Syntax (C#)
```csharp
public static void SetPointOrientationType(
	Document doc,
	ElementId refPointId,
	AdaptivePointOrientationType orientationType
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The Document
- **refPointId** (`Autodesk.Revit.DB.ElementId`) - The ReferencePoint id
- **orientationType** (`Autodesk.Revit.DB.AdaptivePointOrientationType`) - Orientation type of the Adaptive Placement Point.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId refPointId does not correspond to a valid ReferencePoint.
 -or-
 The Element corresponding to ElementId refPointId does not belong to an Adaptive Family.
 -or-
 The ElementId refPointId does not correspond to an Adaptive Placement Point.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation failed.

