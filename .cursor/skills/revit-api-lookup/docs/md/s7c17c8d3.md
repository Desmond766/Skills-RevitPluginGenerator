---
kind: method
id: M:Autodesk.Revit.DB.Structure.IRebarUpdateServer.GetCustomHandleName(Autodesk.Revit.DB.Structure.RebarHandleNameData)
source: html/7f072a66-48c3-43d1-5d3e-a8a5ae787477.htm
---
# Autodesk.Revit.DB.Structure.IRebarUpdateServer.GetCustomHandleName Method

This function should return the name of the handle.

## Syntax (C#)
```csharp
bool GetCustomHandleName(
	RebarHandleNameData handleNameData
)
```

## Parameters
- **handleNameData** (`Autodesk.Revit.DB.Structure.RebarHandleNameData`) - The class used to output the rebarHandle name.

## Returns
Returns true if the handle name is defined successfully, false otherwise.

## Remarks
This function is called during edit constraints command when the mouse is over a handle or the funtion RebarConstrainedHandle.GetCustomHandleName() is called.

