---
kind: method
id: M:Autodesk.Revit.UI.UIDocument.#ctor(Autodesk.Revit.DB.Document)
source: html/cd1de090-0a23-96d9-cfe5-e5edddf9839f.htm
---
# Autodesk.Revit.UI.UIDocument.#ctor Method

Use a database level Document to construct a UI-level Document.

## Syntax (C#)
```csharp
public UIDocument(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The database level document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a primary document, it is a linked document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

