---
kind: method
id: M:Autodesk.Revit.Creation.Application.NewAreaCreationData(Autodesk.Revit.DB.ViewPlan,Autodesk.Revit.DB.UV)
source: html/c46276da-93c7-09e9-9082-4aa6692a127f.htm
---
# Autodesk.Revit.Creation.Application.NewAreaCreationData Method

Creates an object which wraps the arguments of Area for batch creation.

## Syntax (C#)
```csharp
public AreaCreationData NewAreaCreationData(
	ViewPlan areaView,
	UV point
)
```

## Parameters
- **areaView** (`Autodesk.Revit.DB.ViewPlan`) - The view of area element.
- **point** (`Autodesk.Revit.DB.UV`) - A point which lies in an enclosed region of area boundary where the new area will reside.

## Returns
The object containing the data needed for area creation.

