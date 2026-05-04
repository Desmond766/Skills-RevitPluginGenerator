---
kind: method
id: M:Autodesk.Revit.DB.PartUtils.GetAssociatedPartMaker(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.LinkElementId)
source: html/8eb8008e-fc94-3bed-4000-270041373bdb.htm
---
# Autodesk.Revit.DB.PartUtils.GetAssociatedPartMaker Method

Gets associated PartMaker for an element.

## Syntax (C#)
```csharp
public static PartMaker GetAssociatedPartMaker(
	Document hostDocument,
	LinkElementId hostOrLinkElementId
)
```

## Parameters
- **hostDocument** (`Autodesk.Revit.DB.Document`) - The document
- **hostOrLinkElementId** (`Autodesk.Revit.DB.LinkElementId`) - The id for the element to be checked for associated Parts

## Returns
The PartMaker element that is making Parts for this element.
 Nothing nullptr a null reference ( Nothing in Visual Basic) if there is no associated PartMaker.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

