---
kind: type
id: T:Autodesk.Revit.DB.Electrical.TemperatureRatingType
source: html/fe7e15d7-c31f-b24c-992f-332e54e9a5ba.htm
---
# Autodesk.Revit.DB.Electrical.TemperatureRatingType

Represents temperature rating type definition information.

## Syntax (C#)
```csharp
public class TemperatureRatingType : ElementType
```

## Remarks
Temperature rating type is defined based on corresponding wire material type. 
It includes type information such as wire size, insulation type, correction factor, etc.
Only the temperature rating types which are retrieved from WireMaterialType can work well, so don't retrieve it from Revit document directly.

