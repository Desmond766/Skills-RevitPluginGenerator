---
kind: method
id: M:Autodesk.Revit.DB.BuildingPadType.CreateDefault(Autodesk.Revit.DB.Document)
source: html/da63eddd-340a-7e33-36b8-4981b3e43e29.htm
---
# Autodesk.Revit.DB.BuildingPadType.CreateDefault Method

Creates a BuildingPadType element and adds it to the document.

## Syntax (C#)
```csharp
public static BuildingPadType CreateDefault(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to be modified.

## Returns
The new BuildingPadType element.

## Remarks
The default BuildiPadType adopts the value of 1.0 for the paremeter of thickness.
 If there is no BuildingPadType existing, will create a new one; otherwise, an exception will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

