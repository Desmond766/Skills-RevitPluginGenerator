---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.HookAngleMatchesRebarShapeDefinition(System.Int32,Autodesk.Revit.DB.ElementId)
zh: 钢筋、配筋
source: html/3a5c4860-23a1-65bc-e825-8277c0720f45.htm
---
# Autodesk.Revit.DB.Structure.Rebar.HookAngleMatchesRebarShapeDefinition Method

**中文**: 钢筋、配筋

Checks that the hook angle of the specified RebarHookType matches the hook angle used in the Rebar's RebarShape at the specified end of the bar.

## Syntax (C#)
```csharp
public bool HookAngleMatchesRebarShapeDefinition(
	int iEnd,
	ElementId proposedHookId
)
```

## Parameters
- **iEnd** (`System.Int32`) - 0 for the start hook, 1 for the end hook.
- **proposedHookId** (`Autodesk.Revit.DB.ElementId`) - The Id of the RebarHookType

## Returns
Returns true if the hook angle of the RebarHookType matches the angle used in the RebarShape at the specified end of the bar.

## Remarks
Also checks that the specified id is a valid RebarHookType.
 If RebarShapeDefinesHooks property of ReinforcementSettings is false (European shapes), every valid hook angle matches RebarShape definition.
 If RebarShapeDefinesHooks property of ReinforcementSettings is true (non-European shapes), hook angle matches RebarShape definition if it is null or equal RebarShape default hook angle.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - iEnd must be 0 or 1.

