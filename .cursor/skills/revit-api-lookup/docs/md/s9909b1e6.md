---
kind: method
id: M:Autodesk.Revit.DB.Steel.SteelElementProperties.GetFabricationUniqueID(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Reference)
source: html/b9b343df-070c-cb88-e892-5796d9e8f738.htm
---
# Autodesk.Revit.DB.Steel.SteelElementProperties.GetFabricationUniqueID Method

This method will return the fabrication id for the given reference.

## Syntax (C#)
```csharp
public static Guid GetFabricationUniqueID(
	Document aDoc,
	Reference reference
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - Document to which the reference belongs.
- **reference** (`Autodesk.Revit.DB.Reference`) - The reference to the element or subelement for which fabrication id is required.

## Returns
The fabrication id of the element or subelement for this reference, if it has fabrication information attached, or an Guid.Empty otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

