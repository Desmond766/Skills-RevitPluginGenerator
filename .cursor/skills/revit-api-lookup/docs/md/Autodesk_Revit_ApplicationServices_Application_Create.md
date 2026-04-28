---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.Create
zh: 创建、新建、生成、建立、新增
source: html/12878046-c6b5-f988-369c-3c3b8be5ad2a.htm
---
# Autodesk.Revit.ApplicationServices.Application.Create Property

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

