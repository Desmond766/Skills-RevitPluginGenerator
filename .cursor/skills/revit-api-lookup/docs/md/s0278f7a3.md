---
kind: method
id: M:Autodesk.Revit.DB.FamilySymbol.SetThermalProperties(Autodesk.Revit.DB.FamilyThermalProperties)
zh: 族类型、族符号
source: html/88a5ae8c-cb5f-4f64-dc25-9a5be661c26e.htm
---
# Autodesk.Revit.DB.FamilySymbol.SetThermalProperties Method

**中文**: 族类型、族符号

Sets the thermal properties for the given FamilySymbol.

## Syntax (C#)
```csharp
public void SetThermalProperties(
	FamilyThermalProperties thermalProperties
)
```

## Parameters
- **thermalProperties** (`Autodesk.Revit.DB.FamilyThermalProperties`) - The new thermal properties. If Nothing nullptr a null reference ( Nothing in Visual Basic) , this unsets custom thermal properties for this FamilySymbol.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The thermal properties are not valid for assignment.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FamilySymbol does not contain thermal properties.

