---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarInSystem.IsRebarInSection(Autodesk.Revit.DB.View)
source: html/7c479fff-51db-8053-a13b-0cfc87e2968d.htm
---
# Autodesk.Revit.DB.Structure.RebarInSystem.IsRebarInSection Method

Identifies if this RebarInSystem is cut by the view plane of the given view.

## Syntax (C#)
```csharp
public bool IsRebarInSection(
	View dBView
)
```

## Parameters
- **dBView** (`Autodesk.Revit.DB.View`) - The view.

## Returns
True if this RebarInSystem is cut by the view plane, false otherwise.

## Remarks
This method applies only for elevations and sections. For any other view types will return false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

