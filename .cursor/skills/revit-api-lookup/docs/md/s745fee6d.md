---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralConnectionApprovalType.Create(Autodesk.Revit.DB.Document,System.String)
zh: 创建、新建、生成、建立、新增
source: html/909e20ae-e44f-095e-775d-604d9600de79.htm
---
# Autodesk.Revit.DB.Structure.StructuralConnectionApprovalType.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new StructuralConnectionApprovalType.

## Syntax (C#)
```csharp
public static StructuralConnectionApprovalType Create(
	Document doc,
	string name
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`)
- **name** (`System.String`) - A name for the new approval type. It must be unique within the document.

## Returns
Created connection approval type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The input name for approval type is not unique in the document.

