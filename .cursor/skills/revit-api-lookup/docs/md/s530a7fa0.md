---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralConnectionHandler.Create(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.ElementId},Autodesk.Revit.DB.ElementId,System.Collections.Generic.IList{Autodesk.Revit.DB.Structure.ConnectionInputPoint})
zh: 创建、新建、生成、建立、新增
source: html/66944c38-1d9d-ee30-8085-d4f375bfa4a4.htm
---
# Autodesk.Revit.DB.Structure.StructuralConnectionHandler.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of a Structural Connection Handler, which is defined by the elements to connect and the additional points.

## Syntax (C#)
```csharp
public static StructuralConnectionHandler Create(
	Document document,
	IList<ElementId> idsToConnect,
	ElementId typeId,
	IList<ConnectionInputPoint> additionalInputPoints
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Revit document.
- **idsToConnect** (`System.Collections.Generic.IList < ElementId >`) - List of element ids of connected elements.
- **typeId** (`Autodesk.Revit.DB.ElementId`) - The type of Structural Connection Handler.
- **additionalInputPoints** (`System.Collections.Generic.IList < ConnectionInputPoint >`) - The array of points that help define the connection.

## Returns
The newly created connection.

## Remarks
Elements should be of the following structural categories: framings (OST_StructuralFraming), columns (OST_StructuralColumns), walls (OST_Walls), floors (OST_Floors) or foundations (OST_StructuralFoundations).
 The first of given elements is set as primary one.
 The placement of the connection takes into account the additional definition points.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - It verifies that we have at least one element id in the list.
 -or-
 The type typeId is not a valid StructuralConnectionHandlerType.
 -or-
 Missing detailed structural connection service implementation.
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

