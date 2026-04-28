---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MEPAnalyticalSystem.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Mechanical.AnalyticalSystemDomain,System.String)
zh: 创建、新建、生成、建立、新增
source: html/1cf0dc6c-c055-fc72-5b53-6c9262fe981f.htm
---
# Autodesk.Revit.DB.Mechanical.MEPAnalyticalSystem.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new analytical system

## Syntax (C#)
```csharp
public static MEPAnalyticalSystem Create(
	Document document,
	AnalyticalSystemDomain domain,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document where the new element will be created.
- **domain** (`Autodesk.Revit.DB.Mechanical.AnalyticalSystemDomain`) - The domain of analytical system to be created.
- **name** (`System.String`) - The name of new analytical system. The actual name may be post-fixed if already exists.

## Returns
The newly created analytical system.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
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

