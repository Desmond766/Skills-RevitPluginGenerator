---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralConnectionHandlerType.Create(Autodesk.Revit.DB.Document,System.String,System.Guid,System.String)
zh: 创建、新建、生成、建立、新增
source: html/f6140539-e2a6-8868-0ce0-07dd08b03dc1.htm
---
# Autodesk.Revit.DB.Structure.StructuralConnectionHandlerType.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new StructuralConnectionHandlerType object.

## Syntax (C#)
```csharp
public static StructuralConnectionHandlerType Create(
	Document pADoc,
	string name,
	Guid guid,
	string familyName
)
```

## Parameters
- **pADoc** (`Autodesk.Revit.DB.Document`) - The document.
- **name** (`System.String`) - The type name.
- **guid** (`System.Guid`) - Connection GUID.
- **familyName** (`System.String`) - Name of system family which created type will belong to.

## Returns
The newly created instance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

