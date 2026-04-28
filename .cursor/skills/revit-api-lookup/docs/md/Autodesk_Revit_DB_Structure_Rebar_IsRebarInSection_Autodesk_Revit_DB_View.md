---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.IsRebarInSection(Autodesk.Revit.DB.View)
zh: 钢筋、配筋
source: html/49fad033-610a-71b5-60f0-0b3d28d7c2c1.htm
---
# Autodesk.Revit.DB.Structure.Rebar.IsRebarInSection Method

**中文**: 钢筋、配筋

Identifies if this Rebar is cut by the view plane of the given view.

## Syntax (C#)
```csharp
public bool IsRebarInSection(
	View dBView
)
```

## Parameters
- **dBView** (`Autodesk.Revit.DB.View`) - The view.

## Returns
True if this Rebar is cut by the view plane, false otherwise.

## Remarks
This method applies only for elevations and sections. For any other view types will return false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

