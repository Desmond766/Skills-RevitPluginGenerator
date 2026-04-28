---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalPanel.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.CurveLoop)
zh: 创建、新建、生成、建立、新增
source: html/fed26b44-d436-fae2-4d3e-ccff6ae337eb.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalPanel.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of an Analytical Panel within the project.

## Syntax (C#)
```csharp
public static AnalyticalPanel Create(
	Document aDoc,
	CurveLoop curveLoop
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - Revit document.
- **curveLoop** (`Autodesk.Revit.DB.CurveLoop`) - CurveLoop for the Analytical Panel.

## Returns
The newly created AnalyticalPanel instance.

## Remarks
CurveLoop must be planar and not self-intersecting.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One of the following requirements is not satisfied :
 - curve loop curveLoop is not planar
 - curve loop curveLoop is self-intersecting
 - curve loop curveLoop contains zero length curves
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

