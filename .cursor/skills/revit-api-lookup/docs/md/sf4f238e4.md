---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.GetOverridableHookParameters(System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId}@,System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId}@,System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId}@,System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId}@)
zh: 钢筋、配筋
source: html/40de7723-ff71-2507-7369-56983b8d2842.htm
---
# Autodesk.Revit.DB.Structure.Rebar.GetOverridableHookParameters Method

**中文**: 钢筋、配筋

Outputs the formula parameter ids defined in the RebarShape family which are associated with hook length and hook tangent length parameters.

## Syntax (C#)
```csharp
public void GetOverridableHookParameters(
	out ISet<ElementId> startHookLengthPrameters,
	out ISet<ElementId> startHookTangentLengthParameters,
	out ISet<ElementId> endHookLengthParameters,
	out ISet<ElementId> endHookTangentLengthParameters
)
```

## Parameters
- **startHookLengthPrameters** (`System.Collections.Generic.ISet < ElementId > %`) - The formula parameter ids defined in the RebarShape family which are associated with start hook length parameters.
- **startHookTangentLengthParameters** (`System.Collections.Generic.ISet < ElementId > %`) - The formula parameter ids defined in the RebarShape family which are associated with start hook tangent length parameters.
- **endHookLengthParameters** (`System.Collections.Generic.ISet < ElementId > %`) - The formula parameter ids defined in the RebarShape family which are associated with end hook length parameters.
- **endHookTangentLengthParameters** (`System.Collections.Generic.ISet < ElementId > %`) - The formula parameter ids defined in the RebarShape family which are associated with end hook tangent length parameters.

## Remarks
Will throw an exception if the hook length override is not enabled.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The ability to override hook lengths is not enabled for this rebar instance. Use enableHookLengthOverride(true) to enable it.

