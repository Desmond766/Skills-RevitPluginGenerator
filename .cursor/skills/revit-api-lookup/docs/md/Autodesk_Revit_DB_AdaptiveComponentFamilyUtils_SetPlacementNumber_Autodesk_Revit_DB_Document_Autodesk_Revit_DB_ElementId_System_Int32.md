---
kind: method
id: M:Autodesk.Revit.DB.AdaptiveComponentFamilyUtils.SetPlacementNumber(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,System.Int32)
source: html/64c94dcd-e950-f1f1-deb0-50b8673775dd.htm
---
# Autodesk.Revit.DB.AdaptiveComponentFamilyUtils.SetPlacementNumber Method

Sets Placement Number of an Adaptive Placement Point.

## Syntax (C#)
```csharp
public static void SetPlacementNumber(
	Document doc,
	ElementId refPointId,
	int placementNumber
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The Document
- **refPointId** (`Autodesk.Revit.DB.ElementId`) - The ReferencePoint id
- **placementNumber** (`System.Int32`) - Placement number of the Adaptive Placement Point.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId refPointId does not correspond to a valid ReferencePoint.
 -or-
 The Element corresponding to ElementId refPointId does not belong to an Adaptive Family.
 -or-
 The ElementId refPointId does not correspond to an Adaptive Placement Point.
 -or-
 The number placementNumber is out of range.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation failed.

