---
kind: method
id: M:Autodesk.Revit.DB.PointCloudInstance.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Transform)
zh: 创建、新建、生成、建立、新增
source: html/d348f6b8-75b5-dc11-821f-927d575d83f8.htm
---
# Autodesk.Revit.DB.PointCloudInstance.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of a point cloud based on an input point cloud type and transformation.

## Syntax (C#)
```csharp
public static PointCloudInstance Create(
	Document document,
	ElementId typeId,
	Transform transform
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the new instance is created
- **typeId** (`Autodesk.Revit.DB.ElementId`) - The element id of the PointCloudType.
- **transform** (`Autodesk.Revit.DB.Transform`) - The transform that defines the placement of the instance in the Revit document coordinate system.

## Returns
The newly created point cloud instance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId typeId is not a valid PointCloudType.
 -or-
 document is not a project document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

