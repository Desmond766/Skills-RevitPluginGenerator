---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralConnectionHandler.AddReferences(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.Reference})
source: html/e3df730c-4e40-92ee-714c-f2beae290839.htm
---
# Autodesk.Revit.DB.Structure.StructuralConnectionHandler.AddReferences Method

Adds references to the connection.
 All references should be of applicable category.

## Syntax (C#)
```csharp
public void AddReferences(
	Document document,
	IList<Reference> picks
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **picks** (`System.Collections.Generic.IList < Reference >`) - The array containing picks of input elements to be added.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more picks was not permitted to be add to the connection.
 -or-
 One or more picks was not permitted to be added to the connection.
 Picks should not be duplicated.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

