---
kind: method
id: M:Autodesk.Revit.DB.SelectionFilterElement.Create(Autodesk.Revit.DB.Document,System.String)
zh: 创建、新建、生成、建立、新增
source: html/5c70f0d8-1a1c-e850-eb69-52d36070eba9.htm
---
# Autodesk.Revit.DB.SelectionFilterElement.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new SelectionFilterElement in the given document.

## Syntax (C#)
```csharp
public static SelectionFilterElement Create(
	Document document,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which to create the SelectionFilterElement.
- **name** (`System.String`) - The name for the new SelectionFilterElement.

## Returns
The new SelectionFilterElement.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name is an empty string or contains only whitespace.
 -or-
 name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 The given value for name is already in use as a filter element name.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

