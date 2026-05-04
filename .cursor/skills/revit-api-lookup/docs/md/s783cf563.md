---
kind: method
id: M:Autodesk.Revit.DB.IFC.ImporterIFCUtils.CreateEmptyFamily(Autodesk.Revit.DB.IFC.ImporterIFC,Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,System.String)
source: html/6397819b-d73f-e6fe-532d-7b701e6e5dd1.htm
---
# Autodesk.Revit.DB.IFC.ImporterIFCUtils.CreateEmptyFamily Method

Creates an empty family of a given category.

## Syntax (C#)
```csharp
public static ElementId CreateEmptyFamily(
	ImporterIFC importerIFC,
	Document aDoc,
	ElementId catId,
	string familyName
)
```

## Parameters
- **importerIFC** (`Autodesk.Revit.DB.IFC.ImporterIFC`) - The importer.
- **aDoc** (`Autodesk.Revit.DB.Document`) - The document to create the family.
- **catId** (`Autodesk.Revit.DB.ElementId`) - The category id.
- **familyName** (`System.String`) - The family name.

## Returns
The created family id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

