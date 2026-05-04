---
kind: method
id: M:Autodesk.Revit.DB.SketchEditScope.#ctor(Autodesk.Revit.DB.Document,System.String)
source: html/897869be-343e-4dc1-323d-717336374b00.htm
---
# Autodesk.Revit.DB.SketchEditScope.#ctor Method

Instantiates a SketchEditScope object.

## Syntax (C#)
```csharp
public SketchEditScope(
	Document document,
	string transactionName
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document for which this SketchEditScope is going to be used.
- **transactionName** (`System.String`) - The name that will appear in the Undo menu in Revit after the SketchEditScope is successfully committed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a primary document, it is a linked document.
 -or-
 document is not a project document.
 -or-
 transactionName is an empty string.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

