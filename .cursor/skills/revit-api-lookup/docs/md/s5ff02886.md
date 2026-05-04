---
kind: type
id: T:Autodesk.Revit.DB.Electrical.VoltageType
source: html/6b462685-b825-f8f9-f218-035107f7aaf0.htm
---
# Autodesk.Revit.DB.Electrical.VoltageType

Represents electrical voltage type. An electrical voltage type define a range of voltages,
and circuits can be created between components with rated voltages that do not precisely match the voltage definition value.

## Syntax (C#)
```csharp
public class VoltageType : ElementType
```

## Remarks
Actual, minimum and maximum value of voltage type can retrieved through properties, but only can
be modified through SetVoltageValue method. All the unit of voltage properties in this class is volt.

