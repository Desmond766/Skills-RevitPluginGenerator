---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalToPhysicalAssociationManager.IsPhysicalElement(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/9fa06267-c3b6-f681-43f5-9027948ab0cb.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalToPhysicalAssociationManager.IsPhysicalElement Method

Returns true if the element is a physical element.

## Syntax (C#)
```csharp
public static bool IsPhysicalElement(
	Document doc,
	ElementId id
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - Revit document.
- **id** (`Autodesk.Revit.DB.ElementId`) - The element to be checked.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

