---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.Duct.IsDuctTypeId(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 风管
source: html/24590b81-e980-048c-b5cf-15a978699ace.htm
---
# Autodesk.Revit.DB.Mechanical.Duct.IsDuctTypeId Method

**中文**: 风管

Checks if given type is valid duct type.

## Syntax (C#)
```csharp
public static bool IsDuctTypeId(
	Document document,
	ElementId ductTypeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **ductTypeId** (`Autodesk.Revit.DB.ElementId`) - ElementId of the duct type to check.

## Returns
True if duct type can used for this duct, false otherwise.

## Remarks
A type is valid for duct if it can be used to the duct element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

