---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.RebarShapeMatchesCurvesHooksAndEndTreatment(Autodesk.Revit.DB.Structure.RebarShape,Autodesk.Revit.DB.Structure.RebarBarType,Autodesk.Revit.DB.XYZ,System.Collections.Generic.IList{Autodesk.Revit.DB.Curve},Autodesk.Revit.DB.Structure.RebarHookType,Autodesk.Revit.DB.Structure.RebarHookType,Autodesk.Revit.DB.Structure.RebarHookOrientation,Autodesk.Revit.DB.Structure.RebarHookOrientation,System.Double,System.Double,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
zh: 钢筋、配筋
source: html/8fd9c444-b123-7f85-479b-aa55ce74ade6.htm
---
# Autodesk.Revit.DB.Structure.Rebar.RebarShapeMatchesCurvesHooksAndEndTreatment Method

**中文**: 钢筋、配筋

Checks if rebarShape matches curves, hooks and end treatment.
 If the RebarShapeDefinesHooks flag in ReinforcementSettings has been set to false, then this method will ignore the hook information.
 If the RebarShapeDefinesEndTreatment flag in ReinforcementSettings has been set to false, then this method will ignore the end treatment information.

## Syntax (C#)
```csharp
public static bool RebarShapeMatchesCurvesHooksAndEndTreatment(
	RebarShape rebarShape,
	RebarBarType barType,
	XYZ norm,
	IList<Curve> curves,
	RebarHookType startHook,
	RebarHookType endHook,
	RebarHookOrientation startHookOrient,
	RebarHookOrientation endHookOrient,
	double hookRotationAngleAtStart,
	double hookRotationAngleAtEnd,
	ElementId endTreatmentTypeIdAtStart,
	ElementId endTreatmentTypeIdAtEnd
)
```

## Parameters
- **rebarShape** (`Autodesk.Revit.DB.Structure.RebarShape`) - A RebarShape element that defines the shape of the rebar.
- **barType** (`Autodesk.Revit.DB.Structure.RebarBarType`) - A RebarBarType element that defines bar diameter, bend radius and material of the rebar.
- **norm** (`Autodesk.Revit.DB.XYZ`) - The normal to the plane that the rebar curves lie on.
- **curves** (`System.Collections.Generic.IList < Curve >`) - An array of curves that define the shape of the rebar curves.
 They must belong to the plane defined by the normal and origin.
 Bends and hooks should not be included in the array of curves.
- **startHook** (`Autodesk.Revit.DB.Structure.RebarHookType`) - A RebarHookType element that defines the hook for the start of the bar.
- **endHook** (`Autodesk.Revit.DB.Structure.RebarHookType`) - A RebarHookType element that defines the hook for the end of the bar.
- **startHookOrient** (`Autodesk.Revit.DB.Structure.RebarHookOrientation`) - Defines the orientation of the hook plane at the start of the rebar with respect to the orientation of the first curve and the plane normal.
 Only two values are permitted:
 Value = Right: The hook is on your right as you stand at the end of the bar,
 with the bar behind you, taking the bar's normal as "up."
 Value = Left: The hook is on your left as you stand at the end of the bar,
 with the bar behind you, taking the bar's normal as "up."
- **endHookOrient** (`Autodesk.Revit.DB.Structure.RebarHookOrientation`) - Defines the orientation of the hook plane at the end of the rebar with respect to the orientation of the last curve and the plane normal.
 Only two values are permitted:
 Value = Right: The hook is on your right as you stand at the end of the bar,
 with the bar behind you, taking the bar's normal as "up."
 Value = Left: The hook is on your left as you stand at the end of the bar,
 with the bar behind you, taking the bar's normal as "up."
- **hookRotationAngleAtStart** (`System.Double`) - The out of plane hook rotation angle at the start of the bar.
- **hookRotationAngleAtEnd** (`System.Double`) - The out of plane hook rotation angle at the end of the bar.
- **endTreatmentTypeIdAtStart** (`Autodesk.Revit.DB.ElementId`) - The end treatment type id at the start of the bar.
- **endTreatmentTypeIdAtEnd** (`Autodesk.Revit.DB.ElementId`) - The end treatment type id at the end of the bar.

## Returns
True if rebarShape matches curves and hooks.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input curves is empty.
 -or-
 The input curves contains at least one curve which is not a bound Line or bound Arc
 and is not supported for this operation.
 -or-
 curves do not form a valid CurveLoop.
 -or-
 The input curves contains at least one helical curve and is not supported for this operation.
 -or-
 the parameter endTreatmentTypeIdAtStart is not an EndTreatmentType element.
 -or-
 the parameter endTreatmentTypeIdAtEnd is not an EndTreatmentType element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - norm has zero length.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration

