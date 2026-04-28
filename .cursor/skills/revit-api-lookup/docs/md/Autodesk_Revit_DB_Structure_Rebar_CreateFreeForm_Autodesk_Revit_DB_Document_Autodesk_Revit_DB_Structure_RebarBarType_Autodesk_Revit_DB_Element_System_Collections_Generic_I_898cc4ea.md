---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.CreateFreeForm(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Structure.RebarBarType,Autodesk.Revit.DB.Element,System.Collections.Generic.IList{System.Collections.Generic.IList{Autodesk.Revit.DB.Curve}},Autodesk.Revit.DB.Structure.RebarFreeFormValidationResult@)
zh: 钢筋、配筋
source: html/e412ef5a-baa0-64e3-858e-65f79316850a.htm
---
# Autodesk.Revit.DB.Structure.Rebar.CreateFreeForm Method

**中文**: 钢筋、配筋

Creates a free form rebar that will be unconstrained. Constraints can't be added later to this rebar.

## Syntax (C#)
```csharp
public static Rebar CreateFreeForm(
	Document doc,
	RebarBarType barType,
	Element host,
	IList<IList<Curve>> curves,
	out RebarFreeFormValidationResult error
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - A document.
- **barType** (`Autodesk.Revit.DB.Structure.RebarBarType`) - A RebarBarType element that defines bar diameter, bend radius and material of the rebar.
- **host** (`Autodesk.Revit.DB.Element`) - The element to which the rebar belongs. The element must support rebar hosting.
- **curves** (`System.Collections.Generic.IList < IList < Curve >>`) - Each array of curves represent a bar in the set.
- **error** (`Autodesk.Revit.DB.Structure.RebarFreeFormValidationResult %`) - Will be Success if everything is ok, otherwise the failure reason.

## Returns
The newly created free form Rebar Instance.

## Remarks
This function can fail due to following reasons: One or more of the input curves was null. One or more of the input curves was unbounded. Curves doesn't form a valid curve loop, it forms 0, 2 or more curve loops. A rebar constructed from curves can't be bent according to the bending radius.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - host is not a valid rebar host.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

