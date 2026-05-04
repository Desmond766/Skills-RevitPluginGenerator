---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalDemandFactorDefinition.Create(Autodesk.Revit.DB.Document,System.String)
zh: 创建、新建、生成、建立、新增
source: html/e6a68683-24ac-2ea8-72d8-bd9228802df4.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalDemandFactorDefinition.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of a demand factor definition.

## Syntax (C#)
```csharp
public static ElectricalDemandFactorDefinition Create(
	Document ADoc,
	string strName
)
```

## Parameters
- **ADoc** (`Autodesk.Revit.DB.Document`) - The document where the element will be created and added.
- **strName** (`System.String`) - The name of the electrical demand factor definition to be created.

## Returns
The newly created demand factor definition element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

