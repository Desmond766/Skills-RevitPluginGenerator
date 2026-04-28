---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.CreateAlternateGUID(Autodesk.Revit.DB.Element)
source: html/7eee1508-c064-bc8d-ed79-76366948f15f.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.CreateAlternateGUID Method

Creates a GUID for the given element.

## Syntax (C#)
```csharp
public static string CreateAlternateGUID(
	Element pElement
)
```

## Parameters
- **pElement** (`Autodesk.Revit.DB.Element`) - The element.

## Returns
The guid string.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

