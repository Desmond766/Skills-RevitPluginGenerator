---
kind: method
id: M:Autodesk.Revit.DB.FamilySymbol.GetThermalProperties
zh: 族类型、族符号
source: html/ee19d344-addf-af6e-255b-725103cf2bd7.htm
---
# Autodesk.Revit.DB.FamilySymbol.GetThermalProperties Method

**中文**: 族类型、族符号

Gets the thermal properties for the given FamilySymbol.

## Syntax (C#)
```csharp
public FamilyThermalProperties GetThermalProperties()
```

## Returns
The thermal properties. Nothing nullptr a null reference ( Nothing in Visual Basic) if the family symbol does not contain thermal properties.

## Remarks
Doors, windows, and curtain wall panels will have thermal properties.

