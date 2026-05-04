---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterElement.Create(Autodesk.Revit.DB.Document,System.String,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
zh: 创建、新建、生成、建立、新增
source: html/afa22520-52de-c6b3-fac8-246fe2f8e4fe.htm
---
# Autodesk.Revit.DB.ParameterFilterElement.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new ParameterFilterElement in the given document.

## Syntax (C#)
```csharp
public static ParameterFilterElement Create(
	Document aDocument,
	string name,
	ICollection<ElementId> categories
)
```

## Parameters
- **aDocument** (`Autodesk.Revit.DB.Document`) - The document in which to create the ParameterFilterElement.
- **name** (`System.String`) - The user-visible name for the new ParameterFilterElement.
- **categories** (`System.Collections.Generic.ICollection < ElementId >`) - The categories for the new ParameterFilterElement.

## Returns
A pointer to the new ParameterFilterElement.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name is an empty string or contains only whitespace.
 -or-
 name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 The given value for name is already in use as a filter element name.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

