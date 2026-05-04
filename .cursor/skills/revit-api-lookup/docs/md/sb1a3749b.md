---
kind: method
id: M:Autodesk.Revit.DB.Reference.ConvertToStableRepresentation(Autodesk.Revit.DB.Document)
source: html/9d821d63-5b4a-b814-25b2-b92f7d5d1425.htm
---
# Autodesk.Revit.DB.Reference.ConvertToStableRepresentation Method

Converts the reference to a stable String representation.

## Syntax (C#)
```csharp
public string ConvertToStableRepresentation(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.

## Remarks
The stable representation can be used to preserve and restore the reference later in the 
same Revit session or even in a different session where the same document is present. Use
 ParseFromStableRepresentation(Document, String) to restore the reference.
The representation is based on the internal Revit structure and is not intended to be parsed expect by 
 ParseFromStableRepresentation(Document, String) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - document was Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidObjectException** - Reference contained element ids not found in this document.

