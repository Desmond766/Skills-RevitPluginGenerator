---
kind: method
id: M:Autodesk.Revit.DB.Document.EraseSchemaAndAllEntities(Autodesk.Revit.DB.ExtensibleStorage.Schema)
zh: 文档、文件
source: html/50debcb0-3c4f-b32b-2edb-8a6ef7b4bf8d.htm
---
# Autodesk.Revit.DB.Document.EraseSchemaAndAllEntities Method

**中文**: 文档、文件

Erases Schema and all its Entities from the document.

## Syntax (C#)
```csharp
public void EraseSchemaAndAllEntities(
	Schema schema
)
```

## Parameters
- **schema** (`Autodesk.Revit.DB.ExtensibleStorage.Schema`) - The Schema to erase.

## Remarks
The Schema remains in memory.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - No write access to this Schema.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

