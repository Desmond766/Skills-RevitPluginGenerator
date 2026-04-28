---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MechanicalSystem.GetStaticPressure
source: html/52f18d19-a997-0b70-6e08-e719a7fddeb6.htm
---
# Autodesk.Revit.DB.Mechanical.MechanicalSystem.GetStaticPressure Method

Gets the static pressure of this mechanical system.

## Syntax (C#)
```csharp
public double GetStaticPressure()
```

## Remarks
The system static pressure is calculated in the non-blocking evaluation framework. The caller may set up callbacks that react to the asynchronous calculation results.
 If no callback is set up (e.g, called from third-party applications), the calculation is automatically switched to synchronous calculation so the caller
 can access the up-to-date result. Similarly, the public method get_ParameterValue(BuiltInParameter.RBS_DUCT_STATIC_PRESSURE) has the same behavior. Due to this
 change, the parameter RBS_DUCT_STATIC_PRESSURE no longer supports dynamic model update.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The static pressure can not be calculated for this system.

