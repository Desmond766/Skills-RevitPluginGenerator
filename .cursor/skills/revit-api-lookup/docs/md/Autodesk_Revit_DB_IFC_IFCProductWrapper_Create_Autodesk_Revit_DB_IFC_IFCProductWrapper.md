---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCProductWrapper.Create(Autodesk.Revit.DB.IFC.IFCProductWrapper)
zh: 创建、新建、生成、建立、新增
source: html/1e2a3510-f0b9-c8eb-79e0-e005ebdb5ead.htm
---
# Autodesk.Revit.DB.IFC.IFCProductWrapper.Create Method

**中文**: 创建、新建、生成、建立、新增

Establishes a new product manager for elements and objects derived from a parent product manager.

## Syntax (C#)
```csharp
public static IFCProductWrapper Create(
	IFCProductWrapper pProductWrapper
)
```

## Parameters
- **pProductWrapper** (`Autodesk.Revit.DB.IFC.IFCProductWrapper`) - The parent product manager.

## Returns
The new product manager.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

