---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralConnectionHandlerType.CreateDefaultStructuralConnectionHandlerType(Autodesk.Revit.DB.Document)
source: html/3334270c-e2eb-855c-b8d6-4a7f0388ebe8.htm
---
# Autodesk.Revit.DB.Structure.StructuralConnectionHandlerType.CreateDefaultStructuralConnectionHandlerType Method

Creates a new StructuralConnectionHandlerType object with a default name.

## Syntax (C#)
```csharp
public static ElementId CreateDefaultStructuralConnectionHandlerType(
	Document pADoc
)
```

## Parameters
- **pADoc** (`Autodesk.Revit.DB.Document`) - The document.

## Returns
The newly created type id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

