---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.FluidType.Create(Autodesk.Revit.DB.Document,System.String)
zh: 创建、新建、生成、建立、新增
source: html/bda91043-7a2f-c2a6-8de4-0ac6275240fa.htm
---
# Autodesk.Revit.DB.Plumbing.FluidType.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new empty fluid type and adds it to the document.

## Syntax (C#)
```csharp
public static FluidType Create(
	Document document,
	string fluidTypeName
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **fluidTypeName** (`System.String`) - The name of fluid type.

## Returns
The newly created fluid type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

