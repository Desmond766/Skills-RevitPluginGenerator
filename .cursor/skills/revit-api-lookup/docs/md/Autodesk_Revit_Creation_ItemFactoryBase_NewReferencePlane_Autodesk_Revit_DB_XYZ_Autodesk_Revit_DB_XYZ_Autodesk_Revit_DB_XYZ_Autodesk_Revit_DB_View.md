---
kind: method
id: M:Autodesk.Revit.Creation.ItemFactoryBase.NewReferencePlane(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.View)
source: html/1c618038-3801-0f60-9c12-a5923dc87a2c.htm
---
# Autodesk.Revit.Creation.ItemFactoryBase.NewReferencePlane Method

Creates a new instance of ReferencePlane.

## Syntax (C#)
```csharp
public ReferencePlane NewReferencePlane(
	XYZ bubbleEnd,
	XYZ freeEnd,
	XYZ cutVec,
	View pView
)
```

## Parameters
- **bubbleEnd** (`Autodesk.Revit.DB.XYZ`) - The bubble end applied to reference plane.
- **freeEnd** (`Autodesk.Revit.DB.XYZ`) - The free end applied to reference plane.
- **cutVec** (`Autodesk.Revit.DB.XYZ`) - The cut vector apply to reference plane, should perpendicular 
to the vector (bubbleEnd-freeEnd).
- **pView** (`Autodesk.Revit.DB.View`) - The specific view apply to the Reference plane.

## Returns
The newly created reference plane.

## Remarks
The specific view is applied to the Reference plane only for certain view types:
 Legend DraftingView DrawingSheet

