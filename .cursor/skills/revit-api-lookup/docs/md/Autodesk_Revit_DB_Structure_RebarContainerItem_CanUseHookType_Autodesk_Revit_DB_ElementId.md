---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerItem.CanUseHookType(Autodesk.Revit.DB.ElementId)
source: html/1a969227-e826-316a-7cef-a0d2beb2b948.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerItem.CanUseHookType Method

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

