---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalOpening.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.CurveLoop,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/3ef8f558-c706-9972-ad70-594f6762e7a9.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalOpening.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of an Analytical Opening within the project.

## Syntax (C#)
```csharp
public static AnalyticalOpening Create(
	Document aDoc,
	CurveLoop curveLoop,
	ElementId panelId
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - Revit document.
- **curveLoop** (`Autodesk.Revit.DB.CurveLoop`) - CurveLoop for the Analytical Opening.
- **panelId** (`Autodesk.Revit.DB.ElementId`) - ElementId of the AnalyticalPanel on which we create the Opening.

## Returns
The newly created AnalyticalOpening instance.

## Remarks
CurveLoop must be planar, not self-intersecting and in the same plane as the Analytical Panel.
 CurveLoop must intersect or to be inside the AnalyticalPanel contour.
 PanelId must be the ElementId of an AnalyticalPanel otherwise an exception is thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One of the following requirements is not satisfied :
 - curve loop curveLoop is not planar
 - curve loop curveLoop is self-intersecting
 - curve loop curveLoop contains zero length curves
 - curve loop curveLoop is not inside or does not intersect the AnalyticalPanel on which we want to create the Opening.
 - panelId is not the ElementId of an AnalyticalPanel
 - curve loop curveLoop is not in the same plane as the Analytical Panel
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

