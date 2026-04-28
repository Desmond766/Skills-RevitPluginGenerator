---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCProductWrapper.Create(Autodesk.Revit.DB.IFC.IFCProductWrapper,System.Boolean)
zh: 创建、新建、生成、建立、新增
source: html/26cf5730-2491-c14f-41e1-d84aa4bbc1d9.htm
---
# Autodesk.Revit.DB.IFC.IFCProductWrapper.Create Method

**中文**: 创建、新建、生成、建立、新增

Establishes a new product manager for elements and objects derived from a parent product manager, allowing override of allowRelateToLevel

## Syntax (C#)
```csharp
public static IFCProductWrapper Create(
	IFCProductWrapper pProductWrapper,
	bool allowRelateToLevel
)
```

## Parameters
- **pProductWrapper** (`Autodesk.Revit.DB.IFC.IFCProductWrapper`) - The parent product manager.
- **allowRelateToLevel** (`System.Boolean`) - True to allow associated elements and objects to relate to a level, false to never allow such a
 relationship.

## Returns
The new product manager.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

