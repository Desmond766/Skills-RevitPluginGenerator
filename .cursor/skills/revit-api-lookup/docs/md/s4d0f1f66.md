---
kind: type
id: T:Autodesk.Revit.DB.Electrical.WireMaterialType
source: html/3d05ec79-0289-c6d1-2a13-7e6b07241afd.htm
---
# Autodesk.Revit.DB.Electrical.WireMaterialType

Represents electrical wire material type definition information of wire type.

## Syntax (C#)
```csharp
public class WireMaterialType : ElementType
```

## Remarks
All the other properties of wire type are based on wire material type.
Only the wire material types which are retrieved from ElectricalSetting can work well, so don't retrieve it from Revit project directly.

