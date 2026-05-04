---
kind: method
id: M:Autodesk.Revit.DB.Document.EnableWorksharing(System.String,System.String)
zh: 文档、文件
source: html/7c29717e-1d8c-4e02-20ad-65c53ea8eaaa.htm
---
# Autodesk.Revit.DB.Document.EnableWorksharing Method

**中文**: 文档、文件

Enables worksharing in the document.

## Syntax (C#)
```csharp
public void EnableWorksharing(
	string worksetNameGridLevel,
	string worksetName
)
```

## Parameters
- **worksetNameGridLevel** (`System.String`) - Name of workset for grids and levels.
- **worksetName** (`System.String`) - Name of workset for all other elements.

## Remarks
The document's Undo history will be cleared by this command. As a result, this command and others executed before it cannot be undone.
 All transaction phases (e.g. transactions transaction groups and sub-transaction) that were explicitly started must be finished prior to calling this method.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - worksetNameGridLevel is an empty string.
 -or-
 worksetName is an empty string.
 -or-
 worksetNameGridLevel cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 worksetName cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - This method may not be called during dynamic update.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The document does not allow worksharing to be enabled.
 -or-
 This Document is in an edit mode.
 -or-
 This Document is a workshared document.
 -or-
 There is a transaction phase left open (such as a transaction, sub-transaction of transaction group) at the time of invoking this method.
- **Autodesk.Revit.Exceptions.OperationCanceledException** - Enabling worksharing was cancelled.

