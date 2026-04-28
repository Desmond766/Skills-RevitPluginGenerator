---
kind: method
id: M:Autodesk.Revit.DB.ColorFillLegend.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ)
zh: 创建、新建、生成、建立、新增
source: html/fda03f51-ce31-0cde-a41d-ec0e9885282d.htm
---
# Autodesk.Revit.DB.ColorFillLegend.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates new instance of ColorFillLegend.

## Syntax (C#)
```csharp
public static ColorFillLegend Create(
	Document document,
	ElementId viewId,
	ElementId catetoryId,
	XYZ origin
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The id of the view to place legend in.
- **catetoryId** (`Autodesk.Revit.DB.ElementId`) - The id of category that color fill scheme belongs to.
- **origin** (`Autodesk.Revit.DB.XYZ`) - The origin point of the legend, must be on the view plane.

## Remarks
Use SupportedColorFillCategoryIds () () () to get list of supported categories.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 There's no valid color fill scheme applied for catetoryId in viewId.
 -or-
 The origin is not on the view plane.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

