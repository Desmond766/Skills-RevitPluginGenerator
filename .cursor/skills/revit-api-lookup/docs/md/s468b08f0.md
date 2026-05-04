---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalAnalyticalNode.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Electrical.ElectricalAnalyticalNodeType,System.String)
zh: 创建、新建、生成、建立、新增
source: html/c751bc8b-9141-efbb-3b86-1be8b94a8c69.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalAnalyticalNode.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates an electrical analytical node.

## Syntax (C#)
```csharp
public static ElectricalAnalyticalNode Create(
	Document document,
	ElectricalAnalyticalNodeType type,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document where the new element will be created.
- **type** (`Autodesk.Revit.DB.Electrical.ElectricalAnalyticalNodeType`) - The type of electrical analytical node to be created.
- **name** (`System.String`) - The name of new electrical analytical node. The actual name may be post-fixed if already exists.

## Returns
The newly created electrical analytical node.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 name is an empty string.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
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

