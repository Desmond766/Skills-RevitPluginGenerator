---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralConnectionHandler.CreateGenericConnection(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.ElementId})
source: html/887e1ee2-72cd-b3f4-0d1b-e3cfc82b0f07.htm
---
# Autodesk.Revit.DB.Structure.StructuralConnectionHandler.CreateGenericConnection Method

Creates a new instance of a Structural Connection Handler with a generic type, which defines the connection between given elements.

## Syntax (C#)
```csharp
public static StructuralConnectionHandler CreateGenericConnection(
	Document document,
	IList<ElementId> idsToConnect
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Revit document.
- **idsToConnect** (`System.Collections.Generic.IList < ElementId >`) - The list of element ids of connected elements.

## Returns
The newly created generic connection.

## Remarks
Elements should be of the following structural categories: framings (OST_StructuralFraming), columns (OST_StructuralColumns), walls (OST_Walls), floors (OST_Floors) or foundations (OST_StructuralFoundations).
 The first of given elements is set as the primary one.
 A generic connection type will be created by default, if there is none present in the model.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - It verifies that we have at least one element id in the list.
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

