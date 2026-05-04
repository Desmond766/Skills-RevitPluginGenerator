---
kind: method
id: M:Autodesk.Revit.DB.AdaptiveComponentInstanceUtils.GetInstancePlacementPointElementRefIds(Autodesk.Revit.DB.FamilyInstance)
source: html/7991d0f9-e792-94b0-1170-0b8ea27e48ed.htm
---
# Autodesk.Revit.DB.AdaptiveComponentInstanceUtils.GetInstancePlacementPointElementRefIds Method

Gets Placement Adaptive Point Element Ref ids to which the instance geometry adapts.

## Syntax (C#)
```csharp
public static IList<ElementId> GetInstancePlacementPointElementRefIds(
	FamilyInstance famInst
)
```

## Parameters
- **famInst** (`Autodesk.Revit.DB.FamilyInstance`) - The FamilyInstance.

## Returns
The Placement Adaptive Point Element Ref ids to which the instance geometry adapts.

## Remarks
The output contains placement point ref ids. The element ids are sorted in
 by the placement numbers (increasing order).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The FamilyInstance famInst is not an Adaptive Family Instance.
 -or-
 The FamilyInstance famInst does not have an Adaptive Family Symbol.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation failed.

