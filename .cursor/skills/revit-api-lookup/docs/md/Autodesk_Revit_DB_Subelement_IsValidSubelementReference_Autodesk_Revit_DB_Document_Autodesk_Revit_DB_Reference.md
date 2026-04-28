---
kind: method
id: M:Autodesk.Revit.DB.Subelement.IsValidSubelementReference(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Reference)
source: html/89deea46-e7ab-6e7a-a363-665a2eb4b012.htm
---
# Autodesk.Revit.DB.Subelement.IsValidSubelementReference Method

Checks if given Reference identifies either a valid element or subelement.

## Syntax (C#)
```csharp
public static bool IsValidSubelementReference(
	Document aDoc,
	Reference reference
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - The document.
- **reference** (`Autodesk.Revit.DB.Reference`) - The reference that identifies an element or subelement.

## Returns
True if %reference% identifies a valid element or subelement, false otherwise.

## Remarks
A reference to an element or subelement in a linked document is acceptable.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

