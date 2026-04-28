---
kind: method
id: M:Autodesk.Revit.DB.AssemblyInstance.Create(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId},Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/e0a37a7b-b157-b992-21d2-95f68cc76abd.htm
---
# Autodesk.Revit.DB.AssemblyInstance.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new assembly instance.

## Syntax (C#)
```csharp
public static AssemblyInstance Create(
	Document document,
	ICollection<ElementId> assemblyMemberIds,
	ElementId namingCategoryId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the elements.
- **assemblyMemberIds** (`System.Collections.Generic.ICollection < ElementId >`) - The elements that comprise the assembly.
- **namingCategoryId** (`Autodesk.Revit.DB.ElementId`) - The naming category for the assembly instance.

## Returns
The newly created assembly instance.

## Remarks
Transaction must be committed after calling this method before performing any action on the newly created instance.
 Assembly type is assigned after the transaction for creating assembly instance is complete.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more element ids was not permitted for membership in the assembly instance.
 Elements should be of a valid category and should not be a member of an existing assembly.
 -or-
 This naming category was not valid for an assembly instance containing the proposed members.
 The naming category should match one of the member element categories.
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

