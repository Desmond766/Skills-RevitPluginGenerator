---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralConnectionHandlerType.Create(Autodesk.Revit.DB.Document,System.String,System.Guid,System.String,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/6b32c057-7e8b-7bf8-8bcc-ac1e918c8b60.htm
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
	string familyName,
	ElementId categoryId
)
```

## Parameters
- **pADoc** (`Autodesk.Revit.DB.Document`) - The document.
- **name** (`System.String`) - The type name.
- **guid** (`System.Guid`) - Connection GUID.
- **familyName** (`System.String`) - Name of system family which created type will belong to.
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - Category identity of connection type.

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

