---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MechanicalSystem.GetFlow
source: html/2d5d9ef7-2f4c-ebe2-b1a7-710b0ade9ab2.htm
---
# Autodesk.Revit.DB.Mechanical.MechanicalSystem.GetFlow Method

Gets the flow of this mechanical system.

## Syntax (C#)
```csharp
public double GetFlow()
```

## Remarks
The system flow is calculated in the non-blocking evaluation framework. The caller may set up callbacks that react to the asynchronous calculation results.
 If no callback is set up (e.g, called from third-party applications), the calculation is automatically switched to synchronous calculation so the caller
 can access the up-to-date result. Similarly, the public method get_ParameterValue(BuiltInParameter.RBS_DUCT_FLOW_PARAM) has the same behavior. Due to this
 change, the parameter RBS_DUCT_FLOW_PARAM no longer supports dynamic model update.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The flow can not be calculated for this system.

