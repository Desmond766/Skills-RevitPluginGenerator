---
kind: method
id: M:Autodesk.Revit.DB.Structure.IRebarUpdateServer.TrimExtendCurves(Autodesk.Revit.DB.Structure.RebarTrimExtendData)
source: html/6db89b01-28aa-8b95-f3c0-a0f00cdb84c5.htm
---
# Autodesk.Revit.DB.Structure.IRebarUpdateServer.TrimExtendCurves Method

This function is supposed to trim or extend curves that were obtained from calling GenerateCurves(). Also in this function can be set new constraints for start and end handles.

## Syntax (C#)
```csharp
bool TrimExtendCurves(
	RebarTrimExtendData trimExtendData
)
```

## Parameters
- **trimExtendData** (`Autodesk.Revit.DB.Structure.RebarTrimExtendData`) - Use the members of this class to access the inputs and define any trim/extend actions to be taken for bars in the free form rebar.

## Returns
Returns true if the trim/extend was successful, false otherwise.

## Remarks
This function is called in the regeneration context when at least one data in trimExtendData parameter was changed. It is called immediately after GenerateCurves() and only if GenerateCurves() returns true. If new constraints were created for start or end handle, a new regeneration will take place and the new constraints will become the rebar's actual constraints. If new curves will be added by calling TrimExtendData.AddBarGeometry(), the existing curves in Rebar element will be replaced with these curves. It will not add curves to the existing ones.

