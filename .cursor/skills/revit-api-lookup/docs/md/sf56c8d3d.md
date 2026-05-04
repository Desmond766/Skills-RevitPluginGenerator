---
kind: method
id: M:Autodesk.Revit.DB.GlobalParameter.GetValue
source: html/56eb0e54-eac4-9b51-3122-e4fb065b63f0.htm
---
# Autodesk.Revit.DB.GlobalParameter.GetValue Method

Obtains the curent value of the global parameter.

## Syntax (C#)
```csharp
public ParameterValue GetValue()
```

## Returns
An instance of one of the classes derived from the ParameterValue base class.

## Remarks
Note that a value is always returned regardless of whether the
 parameter is formula-driven, or dimension-driven, or independent. The returned ParameterValue is casted-up an instance of
 one of the derived classes, such as DoubleParameterValue 
 or IntegerParameterValue .

