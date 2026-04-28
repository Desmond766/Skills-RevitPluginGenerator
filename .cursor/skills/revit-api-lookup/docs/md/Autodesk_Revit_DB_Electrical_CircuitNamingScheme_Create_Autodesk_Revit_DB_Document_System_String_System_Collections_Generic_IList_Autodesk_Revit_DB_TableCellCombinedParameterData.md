---
kind: method
id: M:Autodesk.Revit.DB.Electrical.CircuitNamingScheme.Create(Autodesk.Revit.DB.Document,System.String,System.Collections.Generic.IList{Autodesk.Revit.DB.TableCellCombinedParameterData})
zh: 创建、新建、生成、建立、新增
source: html/8b095b28-ee04-af63-fd08-cce3dd18074e.htm
---
# Autodesk.Revit.DB.Electrical.CircuitNamingScheme.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new CircuitNamingScheme.

## Syntax (C#)
```csharp
public static CircuitNamingScheme Create(
	Document document,
	string name,
	IList<TableCellCombinedParameterData> data
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which to create the CircuitNamingScheme.
- **name** (`System.String`) - The name of CircuitNamingScheme.
- **data** (`System.Collections.Generic.IList < TableCellCombinedParameterData >`) - The array of TableCellCombinedParameterData to be set as combined parameters.

## Returns
The newly created CircuitNamingScheme.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name is an empty string or contains only whitespace.
 -or-
 name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 The given value for name is already in use as a CircuitNamingScheme name.
 -or-
 The data contains invalid parameter id.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

