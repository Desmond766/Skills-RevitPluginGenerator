---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalToPhysicalAssociationManager.IsAnalyticalElement(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/626c3ad8-60e1-f7b0-47e9-8e1105b068ec.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalToPhysicalAssociationManager.IsAnalyticalElement Method

Returns true if the element is an analytical element.

## Syntax (C#)
```csharp
public static bool IsAnalyticalElement(
	Document doc,
	ElementId id
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - Revit document.
- **id** (`Autodesk.Revit.DB.ElementId`) - The element to be checked.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

