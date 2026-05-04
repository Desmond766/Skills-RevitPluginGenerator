---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.UsesInstanceGeometry(Autodesk.Revit.DB.FamilyInstance)
source: html/0c4dff47-2150-0615-9d65-7b8f9422861a.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.UsesInstanceGeometry Method

Identifies if the family instance has its own geometry, or uses the symbol's geometry with a transform.

## Syntax (C#)
```csharp
public static bool UsesInstanceGeometry(
	FamilyInstance familyInstance
)
```

## Parameters
- **familyInstance** (`Autodesk.Revit.DB.FamilyInstance`) - The family instance.

## Returns
True if the instance has its own geometry. False if the symbol's geometry is used.

## Remarks
A Family Instance can have its own copy of geometry, or use the symbol's geometry with a transform.
 This method identifies the source of this family instance's geometry.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

