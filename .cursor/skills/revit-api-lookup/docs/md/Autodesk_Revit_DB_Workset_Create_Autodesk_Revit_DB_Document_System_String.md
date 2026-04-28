---
kind: method
id: M:Autodesk.Revit.DB.Workset.Create(Autodesk.Revit.DB.Document,System.String)
zh: 创建、新建、生成、建立、新增
source: html/5f9b639f-7082-2f51-833b-fe5777f83b0b.htm
---
# Autodesk.Revit.DB.Workset.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new workset.

## Syntax (C#)
```csharp
public static Workset Create(
	Document document,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the new instance is created.
- **name** (`System.String`) - The workset name.

## Returns
Returns the newly created workset.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a workshared document.
 -or-
 name is an empty string or contains only whitespace.
 -or-
 name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 The given workset name is already in use.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

