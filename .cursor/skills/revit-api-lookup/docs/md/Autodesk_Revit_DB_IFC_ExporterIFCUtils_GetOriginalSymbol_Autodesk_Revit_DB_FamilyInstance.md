---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetOriginalSymbol(Autodesk.Revit.DB.FamilyInstance)
source: html/816f6d7b-d42b-2ba3-11fd-145649805ad1.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetOriginalSymbol Method

Returns the original family symbol of this family instance, before the instance is modified by
 joins, cuts, coping, extensions, or other post-processing.

## Syntax (C#)
```csharp
public static FamilySymbol GetOriginalSymbol(
	FamilyInstance familyInstance
)
```

## Parameters
- **familyInstance** (`Autodesk.Revit.DB.FamilyInstance`) - The FamilyInstance.

## Returns
The original FamilySymbol.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

