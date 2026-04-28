---
kind: method
id: M:Autodesk.Revit.DB.AngularDimension.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.View,Autodesk.Revit.DB.Arc,System.Collections.Generic.IList{Autodesk.Revit.DB.Reference},Autodesk.Revit.DB.DimensionType)
zh: 创建、新建、生成、建立、新增
source: html/2e3b9201-d5fa-3cdb-53e4-8e204bda1fe5.htm
---
# Autodesk.Revit.DB.AngularDimension.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of an Angular Dimension element within the project.

## Syntax (C#)
```csharp
public static AngularDimension Create(
	Document document,
	View dbView,
	Arc arc,
	IList<Reference> references,
	DimensionType dimensionStyle
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document where new Angular Dimension is created.
- **dbView** (`Autodesk.Revit.DB.View`) - The view in which the Angular Dimension will appear.
- **arc** (`Autodesk.Revit.DB.Arc`) - Arc for the Angular Dimension.
- **references** (`System.Collections.Generic.IList < Reference >`) - The references which the Angular Dimension will witness.
- **dimensionStyle** (`Autodesk.Revit.DB.DimensionType`) - Dimension Style.

## Returns
The newly created Angular Dimension instance, or Nothing nullptr a null reference ( Nothing in Visual Basic) if the operation fails.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - References should be: at least two, non parallel and rays of the arc passed.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

