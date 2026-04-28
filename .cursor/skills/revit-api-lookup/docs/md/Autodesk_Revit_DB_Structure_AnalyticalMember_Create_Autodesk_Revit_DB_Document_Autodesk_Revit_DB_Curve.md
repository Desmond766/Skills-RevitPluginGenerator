---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalMember.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Curve)
zh: 创建、新建、生成、建立、新增
source: html/97853ed7-4457-02cd-5ac3-f03d7d0dbc12.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalMember.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of an Analytical Member within the project.

## Syntax (C#)
```csharp
public static AnalyticalMember Create(
	Document aDoc,
	Curve curve
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - A Revit document.
- **curve** (`Autodesk.Revit.DB.Curve`) - Curve of the analytical member.

## Returns
The newly created Analytical Member instance.

## Remarks
The curve must be bounded.
 The curve can be:
 Line Arc Ellipse

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input curve is not bound.
 -or-
 The provided curve is not supported.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

