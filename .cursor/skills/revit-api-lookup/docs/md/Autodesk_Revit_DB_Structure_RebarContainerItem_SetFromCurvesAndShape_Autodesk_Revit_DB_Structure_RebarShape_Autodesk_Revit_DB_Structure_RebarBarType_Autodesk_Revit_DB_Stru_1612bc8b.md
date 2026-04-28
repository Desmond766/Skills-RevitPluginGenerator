---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerItem.SetFromCurvesAndShape(Autodesk.Revit.DB.Structure.RebarShape,Autodesk.Revit.DB.Structure.RebarBarType,Autodesk.Revit.DB.Structure.RebarHookType,Autodesk.Revit.DB.Structure.RebarHookType,Autodesk.Revit.DB.XYZ,System.Collections.Generic.IList{Autodesk.Revit.DB.Curve},Autodesk.Revit.DB.Structure.RebarHookOrientation,Autodesk.Revit.DB.Structure.RebarHookOrientation)
source: html/1bf70fa9-9647-e168-c1bb-78bcdd7ba851.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerItem.SetFromCurvesAndShape Method

Set an instance of a RebarContainerItem element according to the parameters list.
 The instance will have the default shape parameters from the RebarShape.
 If the RebarShapeDefinesHooks flag in ReinforcementSettings has been set to true,
 then both the curves and hooks must match the RebarShape definition.
 Otherwise, the hooks can be different than the defaults specified in the RebarShape

## Syntax (C#)
```csharp
public void SetFromCurvesAndShape(
	RebarShape rebarShape,
	RebarBarType barType,
	RebarHookType startHook,
	RebarHookType endHook,
	XYZ norm,
	IList<Curve> curves,
	RebarHookOrientation startHookOrient,
	RebarHookOrientation endHookOrient
)
```

## Parameters
- **rebarShape** (`Autodesk.Revit.DB.Structure.RebarShape`) - A RebarShape element that defines the shape of the rebar.
 A RebarShape element matches curves and hooks.
 A RebarShape element provides RebarStyle of the rebar.
- **barType** (`Autodesk.Revit.DB.Structure.RebarBarType`) - A RebarBarType element that defines bar diameter, bend radius and material of the rebar.
- **startHook** (`Autodesk.Revit.DB.Structure.RebarHookType`) - A RebarHookType element that defines the hook for the start of the bar.
 If this parameter is Nothing nullptr a null reference ( Nothing in Visual Basic) , it means to create a rebar with no hook.
- **endHook** (`Autodesk.Revit.DB.Structure.RebarHookType`) - A RebarHookType element that defines the hook for the end of the bar.
 If this parameter is Nothing nullptr a null reference ( Nothing in Visual Basic) , it means to create a rebar with no hook.
- **norm** (`Autodesk.Revit.DB.XYZ`) - The normal to the plane that the rebar curves lie on.
- **curves** (`System.Collections.Generic.IList < Curve >`) - An array of curves that define the shape of the rebar curves.
 They must belong to the plane defined by the normal and origin.
 Bends and hooks should not be included in the array of curves.
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
 The rebarShape has End Treatments
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - norm has zero length.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - curves contains non-fillet arcs with radii that are less than the
 minimum bend radius for the RebarBarType and RebarShape style.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - rebarShape does not match curves.

