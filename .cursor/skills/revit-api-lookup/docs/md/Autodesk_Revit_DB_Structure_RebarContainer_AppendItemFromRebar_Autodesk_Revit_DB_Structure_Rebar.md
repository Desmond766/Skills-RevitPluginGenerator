---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainer.AppendItemFromRebar(Autodesk.Revit.DB.Structure.Rebar)
source: html/b7e0adc7-0f2e-af1e-9224-3f1ae4067e3c.htm
---
# Autodesk.Revit.DB.Structure.RebarContainer.AppendItemFromRebar Method

Appends an Item to the RebarContainer. Fills its data on base of the Rebar.
 Will throw exception if given rebar is not shape driven.
 Will throw exception if given rebar has moved bars in set.

## Syntax (C#)
```csharp
public RebarContainerItem AppendItemFromRebar(
	Rebar rebar
)
```

## Parameters
- **rebar** (`Autodesk.Revit.DB.Structure.Rebar`) - The Rebar.

## Returns
The Rebar Container Item.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The RebarShape of rebar has End Treatments
 -or-
 Can't create container from free-form rebar.
 -or-
 Can't create container from Rebar with moved bars.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

