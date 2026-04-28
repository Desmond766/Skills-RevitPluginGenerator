---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.FluidType.Create(Autodesk.Revit.DB.Document,System.String,Autodesk.Revit.DB.Plumbing.FluidType)
zh: 创建、新建、生成、建立、新增
source: html/d8fdb108-1784-fb1b-d5b1-10d10d08148f.htm
---
# Autodesk.Revit.DB.Plumbing.FluidType.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new fluid type and adds it to the document.

## Syntax (C#)
```csharp
public static FluidType Create(
	Document document,
	string fluidTypeName,
	FluidType basedOnFluidType
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **fluidTypeName** (`System.String`) - The name of new created fluid type.
- **basedOnFluidType** (`Autodesk.Revit.DB.Plumbing.FluidType`) - The existing fluid type which is based on.

## Returns
The newly created fluid type.

## Remarks
The new fluid type will be a duplicate of the input type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

