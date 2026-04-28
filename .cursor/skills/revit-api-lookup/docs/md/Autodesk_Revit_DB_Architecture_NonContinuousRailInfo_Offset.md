---
kind: property
id: P:Autodesk.Revit.DB.Architecture.NonContinuousRailInfo.Offset
zh: 偏移、偏移量
source: html/012bb44c-e534-50db-e21f-912b34baeedb.htm
---
# Autodesk.Revit.DB.Architecture.NonContinuousRailInfo.Offset Property

**中文**: 偏移、偏移量

The side offset of the non-continuous rail from a [!:Autodesk::Revit::DB::Architecture::Railing] from the railing center.

## Syntax (C#)
```csharp
public double Offset { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for offset must be no more than 30000 feet in absolute value.

