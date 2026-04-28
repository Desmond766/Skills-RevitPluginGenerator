---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricSheet.IsValidHost(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/d8f29732-ec68-27c7-b105-084c216be625.htm
---
# Autodesk.Revit.DB.Structure.FabricSheet.IsValidHost Method

Checks whether an element is a valid host for fabric sheet.

## Syntax (C#)
```csharp
public static bool IsValidHost(
	Document document,
	ElementId concreteHostElementId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **concreteHostElementId** (`Autodesk.Revit.DB.ElementId`) - The elementId to check.

## Returns
True if the element is a valid host for fabric sheet, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

