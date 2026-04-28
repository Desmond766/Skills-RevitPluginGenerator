---
kind: method
id: M:Autodesk.Revit.DB.Architecture.MultistoryStairs.Create(Autodesk.Revit.DB.Architecture.Stairs)
zh: 创建、新建、生成、建立、新增
source: html/97782290-9eb0-9559-1012-6d46212b5476.htm
---
# Autodesk.Revit.DB.Architecture.MultistoryStairs.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a multistory stairs from an existing component-based stairs.

## Syntax (C#)
```csharp
public static MultistoryStairs Create(
	Stairs stairs
)
```

## Parameters
- **stairs** (`Autodesk.Revit.DB.Architecture.Stairs`) - A component-based stairs.

## Returns
The newly created element. Use [M:Autodesk.Revit.DB.Architecture.MultistoryStairs.ConnectLevels(System.Collections.Generic.ISet`1{Autodesk.Revit.DB.ElementId})] to extend this to multiple stories and generate stairs groups for each level height.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

