---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerItem.SetFromRebar(Autodesk.Revit.DB.Structure.Rebar)
source: html/e81c0c0c-c49f-f451-7e13-9495eaba527f.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerItem.SetFromRebar Method

Set an instance of a RebarContainerItem element according to a Rebar parameters.
 Will throw exception if given rebar is not shape driven.
 Will throw exception if given rebar has moved bars in set.

## Syntax (C#)
```csharp
public void SetFromRebar(
	Rebar rebar
)
```

## Parameters
- **rebar** (`Autodesk.Revit.DB.Structure.Rebar`) - The Rebar.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The RebarShape of rebar has End Treatments
 -or-
 Can't create container from free-form rebar.
 -or-
 Can't create container from Rebar with moved bars.
 -or-
 Can't create container from Rebar which has excluded bars other than the first and last one.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

