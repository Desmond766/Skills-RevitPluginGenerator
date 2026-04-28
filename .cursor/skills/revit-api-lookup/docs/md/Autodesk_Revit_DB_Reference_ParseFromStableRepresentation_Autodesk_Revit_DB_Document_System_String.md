---
kind: method
id: M:Autodesk.Revit.DB.Reference.ParseFromStableRepresentation(Autodesk.Revit.DB.Document,System.String)
source: html/dc168535-2688-83da-429f-a2d018ff4b43.htm
---
# Autodesk.Revit.DB.Reference.ParseFromStableRepresentation Method

Converts a stable String representation of a reference to a Reference object.

## Syntax (C#)
```csharp
public static Reference ParseFromStableRepresentation(
	Document document,
	string representation
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **representation** (`System.String`) - The reference representation.

## Remarks
Use ConvertToStableRepresentation(Document) to obtain the representation.
The Reference will have only the following information set: 
 ElementReferenceType ElementId 
You will also be able to pass the reference to Document.GetElement(reference) and Element.GetGeometryObjectFromReference(reference)
to obtain the element and geometry object referred to.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - One or more arguments was Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Reference representation could not be successfully parsed, or element id obtained
from reference representation could not be found in this document.

