---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralConnectionHandler.Create(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.ElementId},System.String)
zh: 创建、新建、生成、建立、新增
source: html/eb3a4ccf-1d02-d6db-37b4-5eb795200284.htm
---
# Autodesk.Revit.DB.Structure.StructuralConnectionHandler.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates custom StructuralConnectionHandlerType and StructuralConnectionHandler.

## Syntax (C#)
```csharp
public static StructuralConnectionHandler Create(
	Document document,
	IList<ElementId> elementIds,
	string typeName
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Document.
- **elementIds** (`System.Collections.Generic.IList < ElementId >`) - Elements which are to be used to create custom StructuralConnectionHandlerType.
- **typeName** (`System.String`) - The StructuralConnectionHandlerType name.

## Returns
The created StructuralConnectionHandler which is of just created custom StructuralConnectionHandlerType.

## Remarks
Input Elements are deleted. All the input elements should be of the following structural categories:
 FamilyInstance (structural beams and columns). StructuralConnectionHandler elements associated to the connection. Specific steel connection elements (bolts, anchors, plates, etc). These connection elements will be of type element but with categories related to structural connections, for example:
 OST_StructConnectionWelds OST_StructConnectionHoles OST_StructConnectionModifiers OST_StructConnectionShearStuds OST_StructConnectionBolts OST_StructConnectionAnchors OST_StructConnectionPlates

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - All the input Elements should be of the following structural categories: framings, columns, profiles, plates, bolts, anchors, shear studs, welds or structural connections.
 -or-
 There must be at least one StructuralConnectionHandler among the input Elements.
 Total number of different input elements of input StructuralConnectionHandlers must be lower or equal to 3.
 -or-
 Name must be unique among other existing StructuralConnectionHandlerTypes and cannot contain invalid characters.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

