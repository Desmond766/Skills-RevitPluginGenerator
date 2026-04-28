---
kind: method
id: M:Autodesk.Revit.DB.GlobalParameter.Create(Autodesk.Revit.DB.Document,System.String,Autodesk.Revit.DB.ForgeTypeId)
zh: 创建、新建、生成、建立、新增
source: html/d3a16d9e-50d0-b1e6-3beb-126356afb73f.htm
---
# Autodesk.Revit.DB.GlobalParameter.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new Global Parameter in the given document.

## Syntax (C#)
```csharp
public static GlobalParameter Create(
	Document document,
	string name,
	ForgeTypeId specTypeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document in which the new parameter is to be created
- **name** (`System.String`) - The name of the new parameter. It must be unique in the document
- **specTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the spec describing the parameter's data type.

## Returns
An instance of the new global parameter

## Remarks
Global parameters may be created only in Project documents, not in families.
 Each global parameter must have a valid name that is unique within the document. To test whether
 a name is unique, use the IsUniqueName(Document, String) method. While global parameters can be created with almost any type of data, there is a few types that
 are not currently supported, such as the ElementId type. Programmers can test whether a particular
 data type is appropriate for a global parameter by using the [!:SpecUtils.IsSpec(ForgeTypeId)] method. Parameters are created as non-reporting initially, but programmers are free to modify the IsReporting 
 property once a global parameter is created and happens to be of a type eligible for reporting.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Global parameters are not supported in the given document.
 A possible cause is that it is not a project document,
 for global parameters are not supported in Revit families.
 -or-
 name is an empty string.
 -or-
 name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 A global parameter with the given name already exists in the document.
 -or-
 specTypeId is not a spec identifier.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

