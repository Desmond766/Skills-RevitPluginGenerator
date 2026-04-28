---
kind: method
id: M:Autodesk.Revit.DB.Structure.IRebarUpdateServer.GetCustomHandles(Autodesk.Revit.DB.Structure.RebarHandlesData)
source: html/37833063-e74a-26bb-bdf8-9700f7a446cb.htm
---
# Autodesk.Revit.DB.Structure.IRebarUpdateServer.GetCustomHandles Method

This function should define all handles that the Rebar has. This function is called when the Rebar is created.

## Syntax (C#)
```csharp
bool GetCustomHandles(
	RebarHandlesData handlesInfoData
)
```

## Parameters
- **handlesInfoData** (`Autodesk.Revit.DB.Structure.RebarHandlesData`) - Use the methods on this class to define the handles for the free form rebar. Revit will use these handles to create appropriate RebarConstraints.

## Returns
Returns true if the handles were defined successfully, false otherwise.

## Remarks
Revit consider the execution failed if we have duplicate tags for custom, start and end handles.

