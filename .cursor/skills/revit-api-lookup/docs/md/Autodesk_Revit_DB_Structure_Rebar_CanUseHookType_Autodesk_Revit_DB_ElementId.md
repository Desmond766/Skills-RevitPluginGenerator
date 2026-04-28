---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.CanUseHookType(Autodesk.Revit.DB.ElementId)
zh: 钢筋、配筋
source: html/1e62e35b-b85b-5ae0-1908-e697ae47e78d.htm
---
# Autodesk.Revit.DB.Structure.Rebar.CanUseHookType Method

**中文**: 钢筋、配筋

Checks if the specified RebarHookType id is of a valid RebarHookType for the Rebar's RebarBarType

## Syntax (C#)
```csharp
public bool CanUseHookType(
	ElementId proposedHookId
)
```

## Parameters
- **proposedHookId** (`Autodesk.Revit.DB.ElementId`) - The Id of the RebarHookType

## Returns
Returns true if the id is of a valid RebarHookType for the Rebar element.

## Remarks
Also, checks that the Style of the Hook matches that of the Rebar's RebarShape

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

