---
kind: method
id: M:Autodesk.Revit.DB.DimensionType.GetEqualityFormula
source: html/086fb666-7be0-f093-516e-670b149be97d.htm
---
# Autodesk.Revit.DB.DimensionType.GetEqualityFormula Method

Gets an ordered list of the entries in the equality formula definition.

## Syntax (C#)
```csharp
public IList<DimensionEqualityLabelFormatting> GetEqualityFormula()
```

## Returns
An ordered list of the entries in the equality formula definition.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The given DimensionType cannot be assigned an equality formula as it is not continuous linear or angular.

