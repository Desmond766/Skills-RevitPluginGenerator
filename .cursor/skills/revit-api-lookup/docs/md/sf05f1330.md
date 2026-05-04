---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalSetting.RemoveWireMaterialType(Autodesk.Revit.DB.Electrical.WireMaterialType)
source: html/d3193518-abc6-0c64-cbf8-332b04bef8ad.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSetting.RemoveWireMaterialType Method

Remove the wire material type from project.

## Syntax (C#)
```csharp
public void RemoveWireMaterialType(
	WireMaterialType materialType
)
```

## Parameters
- **materialType** (`Autodesk.Revit.DB.Electrical.WireMaterialType`) - The wire material type to be removed.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Wire material type can be removed only if it is not currently assigned to any wire type, 
and the last one wire material type can't be removed, otherwise an exception will be thrown.

