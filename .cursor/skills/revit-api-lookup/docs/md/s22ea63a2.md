---
kind: method
id: M:Autodesk.Revit.DB.AdaptiveComponentInstanceUtils.GetInstanceShapeHandlePointElementRefIds(Autodesk.Revit.DB.FamilyInstance)
source: html/c8cdec14-61f6-13f8-b927-deefc131acaf.htm
---
# Autodesk.Revit.DB.AdaptiveComponentInstanceUtils.GetInstanceShapeHandlePointElementRefIds Method

Gets Shape Handle Adaptive Point Element Ref ids to which the instance geometry adapts.

## Syntax (C#)
```csharp
public static IList<ElementId> GetInstanceShapeHandlePointElementRefIds(
	FamilyInstance famInst
)
```

## Parameters
- **famInst** (`Autodesk.Revit.DB.FamilyInstance`) - The FamilyInstance

## Returns
The Shape Handle Adaptive Point Element Ref ids to which the instance geometry adapts.

## Remarks
The output contains shape handle point ref ids.
If there are no shape handle points defined in the Family then the output
 is empty.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The FamilyInstance famInst is not an Adaptive Family Instance.
 -or-
 The FamilyInstance famInst does not have an Adaptive Family Symbol.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation failed.

