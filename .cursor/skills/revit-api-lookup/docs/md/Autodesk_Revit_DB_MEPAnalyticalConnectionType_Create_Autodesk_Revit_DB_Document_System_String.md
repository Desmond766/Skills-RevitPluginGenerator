---
kind: method
id: M:Autodesk.Revit.DB.MEPAnalyticalConnectionType.Create(Autodesk.Revit.DB.Document,System.String)
zh: 创建、新建、生成、建立、新增
source: html/5b10a892-0a51-73e7-f8b1-73cca20c206d.htm
---
# Autodesk.Revit.DB.MEPAnalyticalConnectionType.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates an analytical connection type element.

## Syntax (C#)
```csharp
public static MEPAnalyticalConnectionType Create(
	Document doc,
	string name
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document.
- **name** (`System.String`) - The name of the analytical type to be created.

## Returns
The created analytical connection type element.

## Remarks
The newly created type would have the default pressure loss being 0.
 Use ElementType.duplicate to copy from any existing type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This name is already used by an existing analytical connection type in the document.
 -or-
 name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 name is an empty string.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

