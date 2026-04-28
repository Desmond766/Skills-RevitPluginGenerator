---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.FlexDuct.IsFlexDuctTypeId(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/a598ecef-7854-5b6f-1ffc-b8c09692c202.htm
---
# Autodesk.Revit.DB.Mechanical.FlexDuct.IsFlexDuctTypeId Method

Checks if given type is valid flexible duct type.

## Syntax (C#)
```csharp
public static bool IsFlexDuctTypeId(
	Document document,
	ElementId ductTypeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **ductTypeId** (`Autodesk.Revit.DB.ElementId`) - ElementId of the flexible duct type to check.

## Returns
True if flexible duct type can used for this duct, false otherwise.

## Remarks
A type is valid for flexible duct if it can be used to the flexible duct element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

