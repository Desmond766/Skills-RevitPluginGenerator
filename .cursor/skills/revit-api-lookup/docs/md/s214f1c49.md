---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarHandlePositionData.SetPosition(System.Int32,Autodesk.Revit.DB.XYZ)
source: html/690efb38-6607-4509-d8f5-6c7fd853c9f5.htm
---
# Autodesk.Revit.DB.Structure.RebarHandlePositionData.SetPosition Method

Sets the position for a specified handle. This information is set to the rebar after the API execution is finished successfully.

## Syntax (C#)
```csharp
public void SetPosition(
	int handleTag,
	XYZ position
)
```

## Parameters
- **handleTag** (`System.Int32`) - The tag of the handle.
- **position** (`Autodesk.Revit.DB.XYZ`) - Position of the handle.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input point lies outside of Revit design limits.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

