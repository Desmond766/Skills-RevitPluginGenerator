---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.Zone.CreateAreaBasedLoad(Autodesk.Revit.DB.Document,System.String,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/ea2f5648-08c1-2c26-80fa-1d143b6b4c0c.htm
---
# Autodesk.Revit.DB.Mechanical.Zone.CreateAreaBasedLoad Method

Creates a new instance of an area based load and adds it to the document.

## Syntax (C#)
```csharp
public static Zone CreateAreaBasedLoad(
	Document doc,
	string name,
	ElementId levelId,
	ElementId phaseId
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document where the element will be created and added.
- **name** (`System.String`) - The name of the area based load to be created.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The base level on which the area based load will be created.
- **phaseId** (`Autodesk.Revit.DB.ElementId`) - The associative phase on which the area based load is to exist.

## Returns
The newly created area based load.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 name is an empty string.
 -or-
 The ElementId levelId is not a Level.
 -or-
 The id does not represent a valid phase.
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

