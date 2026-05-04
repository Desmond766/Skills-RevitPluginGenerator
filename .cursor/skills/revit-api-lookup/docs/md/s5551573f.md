---
kind: method
id: M:Autodesk.Revit.DB.Electrical.VoltageType.SetVoltageValue(System.Double,System.Double,System.Double)
source: html/2cd8977a-d328-39ba-ea85-2e05e2aa2351.htm
---
# Autodesk.Revit.DB.Electrical.VoltageType.SetVoltageValue Method

Assign new values to modify voltage type, all of the unit are volt.

## Syntax (C#)
```csharp
public void SetVoltageValue(
	double actualValue,
	double minValue,
	double maxValue
)
```

## Parameters
- **actualValue** (`System.Double`)
- **minValue** (`System.Double`)
- **maxValue** (`System.Double`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Actual value can't be more than minValue or less than maxValue, and all of them can't be negative, 
otherwise the exception will be thrown.

