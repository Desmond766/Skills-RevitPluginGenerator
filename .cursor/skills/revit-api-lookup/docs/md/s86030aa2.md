---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalAnalyticalLoadSet.Create(Autodesk.Revit.DB.Document,System.String)
zh: 创建、新建、生成、建立、新增
source: html/1552184e-755d-1f60-3e40-4178923f44fc.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalAnalyticalLoadSet.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates an electrical analytical load set.

## Syntax (C#)
```csharp
public static ElectricalAnalyticalLoadSet Create(
	Document document,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document where the new element will be created.
- **name** (`System.String`) - The name of new electrical analytical load set. The actual name may be post-fixed if already exists.

## Returns
The newly created electrical analytical loadset.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 name is an empty string.
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

