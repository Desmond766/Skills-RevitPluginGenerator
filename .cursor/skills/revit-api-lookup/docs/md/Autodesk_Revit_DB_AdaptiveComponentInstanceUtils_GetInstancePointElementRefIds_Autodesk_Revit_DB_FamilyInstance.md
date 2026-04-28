---
kind: method
id: M:Autodesk.Revit.DB.AdaptiveComponentInstanceUtils.GetInstancePointElementRefIds(Autodesk.Revit.DB.FamilyInstance)
source: html/b82a3d28-d5e4-c563-8464-5e901cd3c70c.htm
---
# Autodesk.Revit.DB.AdaptiveComponentInstanceUtils.GetInstancePointElementRefIds Method

Gets Adaptive Point Element Ref ids to which the instance geometry adapts.

## Syntax (C#)
```csharp
public static IList<ElementId> GetInstancePointElementRefIds(
	FamilyInstance famInst
)
```

## Parameters
- **famInst** (`Autodesk.Revit.DB.FamilyInstance`) - The FamilyInstance.

## Returns
The Adaptive Point Element Ref ids to which the instance geometry adapts.

## Remarks
The output contains both placement point ref ids and the shape handles
 point ref ids. The order corresponds to the same order as that
 of the Adaptive Points in the Family (which may not be ordered as per
 their placement number).
Will return an empty array if there are no placement points and shape
 handles. To manipulate such an instance the following methods can be
 useful:
 1) RehostAdaptiveComponentInstanceWithNoPlacementPoints()
 2) MoveAdaptiveComponentInstance()

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The FamilyInstance famInst is not an Adaptive Family Instance.
 -or-
 The FamilyInstance famInst does not have an Adaptive Family Symbol.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation failed.

