---
kind: method
id: M:Autodesk.Revit.DB.StairsEditScope.#ctor(Autodesk.Revit.DB.Document,System.String)
source: html/1c753d29-0eab-16f1-de61-12d8ea09803e.htm
---
# Autodesk.Revit.DB.StairsEditScope.#ctor Method

Instantiates a StairsEditScope object.

## Syntax (C#)
```csharp
public StairsEditScope(
	Document document,
	string transactionName
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document for which this StairsEditScope is going to be used.
- **transactionName** (`System.String`) - The name that will appear in the Undo menu in Revit after the StairsEditScope is successfully committed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a primary document, it is a linked document.
 -or-
 document is not a project document.
 -or-
 transactionName is an empty string.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

