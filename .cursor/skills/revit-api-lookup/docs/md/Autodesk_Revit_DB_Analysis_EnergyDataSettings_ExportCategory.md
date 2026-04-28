---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyDataSettings.ExportCategory
source: html/be269eca-22b1-9a1a-7e13-db7f8cdae1e0.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.ExportCategory Property

Value is a category indicating which discipline model will be used for GreenBuildingXML export.

## Syntax (C#)
```csharp
public ElementId ExportCategory { get; set; }
```

## Remarks
OST_Rooms will use the architectural 3d rooms for export.
 OST_MEPSpaces will use the MEP 3d Spaces for export.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The export category is neither OST_Rooms nor OST_MEPSpaces.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

