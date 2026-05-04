---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalLoadClassification.Create(Autodesk.Revit.DB.Document,System.String)
zh: 创建、新建、生成、建立、新增
source: html/323c8700-09d4-badb-06e2-d126173b2f8a.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalLoadClassification.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of load classification and adds it to the document.

## Syntax (C#)
```csharp
public static ElectricalLoadClassification Create(
	Document ADoc,
	string strName
)
```

## Parameters
- **ADoc** (`Autodesk.Revit.DB.Document`) - The document where the element will be created and added.
- **strName** (`System.String`) - The name of the electrical load classification to be created.

## Returns
The newly created load classification element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

