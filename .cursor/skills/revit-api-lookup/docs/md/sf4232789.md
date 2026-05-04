---
kind: method
id: M:Autodesk.Revit.DB.PartUtils.IsValidForCreateParts(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.LinkElementId)
source: html/041b18f8-6cac-6ade-5f37-793f9b68cb0c.htm
---
# Autodesk.Revit.DB.PartUtils.IsValidForCreateParts Method

Identifies if the given element can be used to create parts.

## Syntax (C#)
```csharp
public static bool IsValidForCreateParts(
	Document document,
	LinkElementId hostOrLinkElementId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **hostOrLinkElementId** (`Autodesk.Revit.DB.LinkElementId`) - Id to be tested for validity for creating part.

## Returns
True if this id is valid, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

