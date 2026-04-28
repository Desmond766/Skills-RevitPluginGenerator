---
kind: method
id: M:Autodesk.Revit.DB.Architecture.TopographyEditScope.#ctor(Autodesk.Revit.DB.Document,System.String)
source: html/0f968149-6567-5e03-7e6e-c1911d4cdf55.htm
---
# Autodesk.Revit.DB.Architecture.TopographyEditScope.#ctor Method

Instantiates a TopographyEditScope object.

## Syntax (C#)
```csharp
public TopographyEditScope(
	Document document,
	string transactionName
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document for which this TopographyEditScope is going to be used.
- **transactionName** (`System.String`) - The name that will appear in the Undo menu in Revit after the TopographyEditScope is successfully committed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a primary document, it is a linked document.
 -or-
 document is not a project document.
 -or-
 transactionName is an empty string.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

