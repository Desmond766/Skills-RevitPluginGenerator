---
kind: method
id: M:Autodesk.Revit.DB.PartUtils.GetAssociatedPartMaker(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/e0568bef-0c22-177d-a537-f1cf85285876.htm
---
# Autodesk.Revit.DB.PartUtils.GetAssociatedPartMaker Method

Gets associated PartMaker for an element.

## Syntax (C#)
```csharp
public static PartMaker GetAssociatedPartMaker(
	Document hostDocument,
	ElementId elementId
)
```

## Parameters
- **hostDocument** (`Autodesk.Revit.DB.Document`) - The document
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The id for the element to be checked for associated Parts

## Returns
The PartMaker element that is making Parts for this element.
 Nothing nullptr a null reference ( Nothing in Visual Basic) if there is no associated PartMaker.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

