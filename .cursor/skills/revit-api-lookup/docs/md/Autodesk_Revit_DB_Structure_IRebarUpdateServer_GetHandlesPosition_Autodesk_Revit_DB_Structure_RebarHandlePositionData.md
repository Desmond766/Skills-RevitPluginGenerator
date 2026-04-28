---
kind: method
id: M:Autodesk.Revit.DB.Structure.IRebarUpdateServer.GetHandlesPosition(Autodesk.Revit.DB.Structure.RebarHandlePositionData)
source: html/7f991fe0-6c77-ba43-3d52-64a8c0390809.htm
---
# Autodesk.Revit.DB.Structure.IRebarUpdateServer.GetHandlesPosition Method

This function is supposed to provide the positions of handles defined in GetCustomHandles(). These positions will be shown on screen when the bar constraints are edited.
 If a position for a handle isn't provided, that handle will not be represented on screen while edit constraints. This function is called when edit constraints command is lunched or during edit constraints after a constraint was changed and the curve calculation was done.

## Syntax (C#)
```csharp
bool GetHandlesPosition(
	RebarHandlePositionData handlePositionData
)
```

## Parameters
- **handlePositionData** (`Autodesk.Revit.DB.Structure.RebarHandlePositionData`) - Use the members of this class to access the inputs and define the handle positions for this free form rebar.

## Returns
Returns true if calculation of handle positions was successful, false otherwise.

