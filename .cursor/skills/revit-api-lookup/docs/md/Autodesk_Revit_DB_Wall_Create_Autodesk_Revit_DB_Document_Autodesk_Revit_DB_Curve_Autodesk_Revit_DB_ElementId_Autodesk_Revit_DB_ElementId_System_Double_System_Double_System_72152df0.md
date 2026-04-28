---
kind: method
id: M:Autodesk.Revit.DB.Wall.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Curve,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,System.Double,System.Double,System.Boolean,System.Boolean)
zh: 创建、新建、生成、建立、新增
source: html/0ce4c555-4cee-f5fd-2e84-43cacf34ac5c.htm
---
# Autodesk.Revit.DB.Wall.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new rectangular profile wall within the project using the specified wall type, height, and offset.

## Syntax (C#)
```csharp
public static Wall Create(
	Document document,
	Curve curve,
	ElementId wallTypeId,
	ElementId levelId,
	double height,
	double offset,
	bool flip,
	bool structural
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the new wall is created.
- **curve** (`Autodesk.Revit.DB.Curve`) - A curve representing the base line of the wall.
- **wallTypeId** (`Autodesk.Revit.DB.ElementId`) - Id of the wall type to be used by the new wall instead of the default type.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - Id of the level on which the wall is to be placed.
- **height** (`System.Double`) - The height of the wall other than the default height.
- **offset** (`System.Double`) - Modifies the wall's Base Offset parameter to determine its vertical placement.
- **flip** (`System.Boolean`) - Change which side of the wall is considered to be the inside and outside of the wall.
- **structural** (`System.Boolean`) - If set, specifies that the wall is structural in nature.

## Returns
If successful a new wall object within the project.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The curve argument is not valid for wall creation.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for height must be greater than 0 and no more than 30000 feet.
 -or-
 The given value for offset must be no more than 30000 feet in absolute value.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

