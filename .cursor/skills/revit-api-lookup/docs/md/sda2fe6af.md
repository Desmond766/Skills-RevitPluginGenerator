---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCFamilyInstanceExtrusionExportResults.GetExtrusionHandle
source: html/c02163df-6dfb-2ffa-6618-4a7a53c0e03b.htm
---
# Autodesk.Revit.DB.IFC.IFCFamilyInstanceExtrusionExportResults.GetExtrusionHandle Method

Gets the extruded solid handle generated for the family instance.

## Syntax (C#)
```csharp
public IFCAnyHandle GetExtrusionHandle()
```

## Returns
The handle. If the extrusion analysis failed for the family, this will be a handle with no value assigned.

