---
kind: method
id: M:Autodesk.Revit.DB.DeleteElements.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/d6bc1478-9b98-d441-0265-fe256728f5b1.htm
---
# Autodesk.Revit.DB.DeleteElements.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates an instance of the DeleteElements resolution.

## Syntax (C#)
```csharp
public static FailureResolution Create(
	Document document,
	ElementId id
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document which owns the element to delete.
- **id** (`Autodesk.Revit.DB.ElementId`) - The id of the element that will be deleted when this resolution is chosen.

## Returns
The instance of the DeletedElements resolution.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input id is not valid for deletion.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

