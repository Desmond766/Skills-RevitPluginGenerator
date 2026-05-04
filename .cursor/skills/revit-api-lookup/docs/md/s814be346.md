---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.AddValueString(Autodesk.Revit.DB.Element,Autodesk.Revit.DB.ElementId,System.String)
source: html/76fd2ea8-1d60-5c8b-43f9-23aa68750200.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.AddValueString Method

Adds a string value to a built-in parameter.

## Syntax (C#)
```csharp
public static void AddValueString(
	Element element,
	ElementId builtInParameter,
	string propertyValue
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The element.
- **builtInParameter** (`Autodesk.Revit.DB.ElementId`) - The built-in parameter id.
- **propertyValue** (`System.String`) - The new value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

