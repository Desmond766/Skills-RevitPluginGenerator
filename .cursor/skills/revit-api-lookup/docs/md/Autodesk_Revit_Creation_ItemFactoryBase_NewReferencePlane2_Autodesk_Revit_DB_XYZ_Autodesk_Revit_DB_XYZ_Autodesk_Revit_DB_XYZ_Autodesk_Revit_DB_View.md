---
kind: method
id: M:Autodesk.Revit.Creation.ItemFactoryBase.NewReferencePlane2(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.View)
source: html/8db0c9ac-9dd9-72b8-3939-c1a1c605fb49.htm
---
# Autodesk.Revit.Creation.ItemFactoryBase.NewReferencePlane2 Method

Creates a new instance of ReferencePlane.

## Syntax (C#)
```csharp
public ReferencePlane NewReferencePlane2(
	XYZ bubbleEnd,
	XYZ freeEnd,
	XYZ thirdPnt,
	View pView
)
```

## Parameters
- **bubbleEnd** (`Autodesk.Revit.DB.XYZ`) - The bubble end applied to reference plane.
- **freeEnd** (`Autodesk.Revit.DB.XYZ`) - The free end applied to reference plane.
- **thirdPnt** (`Autodesk.Revit.DB.XYZ`) - A third point needed to define the reference plane.
- **pView** (`Autodesk.Revit.DB.View`) - The specific view apply to the Reference plane.

## Returns
The newly created reference plane.

## Remarks
The specific view is applied to the Reference plane only for certain view types:
 Legend DraftingView DrawingSheet

