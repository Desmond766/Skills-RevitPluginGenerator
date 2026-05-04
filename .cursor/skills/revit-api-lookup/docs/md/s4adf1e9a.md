---
kind: property
id: P:Autodesk.Revit.ApplicationServices.ControlledApplication.Create
zh: 创建、新建、生成、建立、新增
source: html/63042422-6c28-d8db-78f6-594c52701188.htm
---
# Autodesk.Revit.ApplicationServices.ControlledApplication.Create Property

**中文**: 创建、新建、生成、建立、新增

Provides an object that can be used to create new instances of Autodesk Revit API objects.

## Syntax (C#)
```csharp
public Application Create { get; }
```

## Remarks
The Create property returns an object that is used to create application wide utility
and geometric objects within the Autodesk Revit API, such as arrays, sets, lines. This object
should be used when you wish to create an object within the Autodesk Revit application memory,
rather than your own application's memory. If you are performing your own memory management
techniques then it is advisable to create any utility objects via the Create object. For example:
Instead of Dim set As New Autodesk_Revit_ElementSet do Set set = application.Create.NewElementSet()

