---
kind: method
id: M:Autodesk.Revit.DB.Electrical.AreaBasedLoadType.Create(Autodesk.Revit.DB.Document,System.String)
zh: 创建、新建、生成、建立、新增
source: html/86fa33e2-d5d1-7b74-13db-7f0f2de389a6.htm
---
# Autodesk.Revit.DB.Electrical.AreaBasedLoadType.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates an area based load type.

## Syntax (C#)
```csharp
public static AreaBasedLoadType Create(
	Document document,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which to create the area based load type.
- **name** (`System.String`) - The name of new area based load type. The actual name may be post-fixed if already exists.

## Returns
The newly created area based load type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 name is an empty string or contains only whitespace.
 -or-
 name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

