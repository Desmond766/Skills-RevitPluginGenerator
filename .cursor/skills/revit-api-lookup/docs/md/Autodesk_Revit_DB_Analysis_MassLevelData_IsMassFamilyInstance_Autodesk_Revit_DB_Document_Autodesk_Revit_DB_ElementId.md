---
kind: method
id: M:Autodesk.Revit.DB.Analysis.MassLevelData.IsMassFamilyInstance(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/a2bc9949-9c4f-afc4-6c79-38050507e784.htm
---
# Autodesk.Revit.DB.Analysis.MassLevelData.IsMassFamilyInstance Method

Checks if the ElementId is a mass family instance.

## Syntax (C#)
```csharp
public static bool IsMassFamilyInstance(
	Document document,
	ElementId id
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **id** (`Autodesk.Revit.DB.ElementId`) - The ElementId to be checked.

## Returns
True if the ElementId is a mass family instance, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

